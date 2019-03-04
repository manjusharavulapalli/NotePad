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

namespace NoteTakingApp
{
    [Activity(Label = "AddNote")]
    public class AddNote : Activity
    {
        Button _btnsave, _btncancel;
        EditText _txtTitle, _txtDetails;
        DataBaseManager obj;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AddNote);
          
            // Create your application here

            _btnsave = FindViewById<Button>(Resource.Id.btnSave);
            _btncancel = FindViewById<Button>(Resource.Id.btnCancel);
            _txtTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            _txtDetails = FindViewById<EditText>(Resource.Id.txtNotes);

           //Generating Events
            _btnsave.Click += _btnsave_Click;
            _btncancel.Click += _btncancel_Click;

            obj = new DataBaseManager();




        }

        public override void OnBackPressed()
        {
            this.Finish();
            StartActivity(typeof(MainActivity));
            base.OnBackPressed();
        }
        private void _btncancel_Click(object sender, EventArgs e)
        {
            this.Finish();
            StartActivity(typeof(MainActivity));
           
        }

        private void _btnsave_Click(object sender, EventArgs e)
        {
            if (_txtTitle.Text != "" && _txtDetails.Text != "")
            {
                obj.AddItem(_txtTitle.Text, _txtDetails.Text);
                Toast.MakeText(this, "Note Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
                
            }
            else
            {
                Toast.MakeText(this, "Enter the Title and Details", ToastLength.Long).Show();
            }
        }
    }
}