using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Text;

namespace NoteTakingApp
{
    [Activity(Label = "EditNotes")]
    public class EditNotes : Activity
    {

        ImageButton btnEdit, btnDelete;

        EditText Ednotes;

        int NoteId; 
         String Note;
        String Details;
        DataBaseManager obj;
        TextView _txtNotesTitle;
        String Title;
        Button _btnBAck;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);//Removing Title 
            SetContentView(Resource.Layout.EditNote);
            // Create your application here

            Ednotes = FindViewById<EditText>(Resource.Id.txtEditNote);
            btnEdit = FindViewById<ImageButton>(Resource.Id.btnEdit);
            btnDelete = FindViewById<ImageButton>(Resource.Id.btnDelete);
           _txtNotesTitle = FindViewById<TextView>(Resource.Id.txtNotesTitle);
            _btnBAck = FindViewById<Button>(Resource.Id.btnBack);

            //Getting the Details
            Note = Intent.GetStringExtra("Details");
            NoteId = Intent.GetIntExtra("NoteId", 0);
            Title = Intent.GetStringExtra("Title");
            _txtNotesTitle.Text = Title;

            Ednotes.Text = Note;
            int position = Note.Length;
            Ednotes.SetSelection(position);     
           
            obj = new DataBaseManager();
            //Generating Events
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            _btnBAck.Click += _btnBAck_Click;


          
        }
        public override void OnBackPressed()
        {
            this.Finish();
            StartActivity(typeof(MainActivity));
            base.OnBackPressed();
        }

        //Click the Back button
        private void _btnBAck_Click(object sender, EventArgs e)
        {
            
            StartActivity(typeof(MainActivity));
            this.Finish();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Alert Dialog For Confirmation
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Delete");
            alertDialog.SetMessage("Are You Sure To Delete??");
            alertDialog.SetButton("Yes", (s, ev) =>
            {
                try
                {
                    obj.DeleteItem(NoteId);
                    Toast.MakeText(this, "Note Deleted", ToastLength.Long).Show();
                    this.Finish();
                    StartActivity(typeof(MainActivity));
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured" + ex.Message);
                }

            });
            alertDialog.SetButton2("No", (s, ev) =>
            {
                return;
            });
            alertDialog.Show();

           
        }


      //Edit Operation
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                obj.EditItem(Ednotes.Text, NoteId);
                Toast.MakeText(this, "Note Edited", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
            }
        }
    }
}