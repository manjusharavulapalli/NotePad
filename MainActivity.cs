using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Collections.Generic;


namespace NoteTakingApp
{
    [Activity(Label = "NoteTakingApp")]
    public class MainActivity : Activity
    {
      


        SearchView _searchView;
        TextView _txtcountNotes;
        ImageButton _btnAdd;
        ListView lstToDoList;

        static string dbName = "dbNotesList.sqlite";
        string dbpath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        List<NoteRec> mylist;
        DataBaseManager objDb;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            this.RequestWindowFeature(WindowFeatures.NoTitle);//Removing the title
            SetContentView(Resource.Layout.Main);


            // Get our button from the layout resource,

            lstToDoList = FindViewById<ListView>(Resource.Id.listView1);

            _txtcountNotes = FindViewById<TextView>(Resource.Id.txtNotesCount);

            _btnAdd = FindViewById<ImageButton>(Resource.Id.btnAdd);
            _searchView = FindViewById<SearchView>(Resource.Id.searchView1);
          
           
           

            CopyDatabase();

             objDb = new DataBaseManager();
             mylist = objDb.ViewAll();
             lstToDoList.Adapter = new DataAdapter(this, mylist);

            _txtcountNotes.Text = "Notes(" + mylist.Count + ")";

            // and attach an event to it

            lstToDoList.ItemClick += LstToDoList_ItemClick;
            _btnAdd.Click += _btnAdd_Click;

            
            _searchView.QueryTextChange += _searchView_QueryTextChange;
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            this.Finish();
            StartActivity(typeof(AddNote));
        }

        private void LstToDoList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
          
            NoteRec EditRec = mylist[e.Position];
            Intent EditItem = new Intent(this, typeof(EditNotes));
            
            EditItem.PutExtra("Details", EditRec.Details);
            EditItem.PutExtra("NoteId", EditRec.NotedId);
            EditItem.PutExtra("Title", EditRec.Title);
            this.Finish();
            StartActivity(EditItem);

        }

       


      

    


        private void _searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            List<NoteRec> SearchRes;
            string compText = e.NewText.ToLower();
            if (compText != "")
            {
                SearchRes = mylist.FindAll(x => (x.Title).ToLower().Contains(compText));
                lstToDoList.Adapter = new DataAdapter(this, SearchRes);
            }
            else
            {
                lstToDoList.Adapter = new DataAdapter(this, mylist);
            }
        }


        public void CopyDatabase()
        {
            try
            {
                if (!File.Exists(dbpath))
                {
                    using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                    {
                        using (BinaryWriter bw = new BinaryWriter(new FileStream(dbpath, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int len = 0;
                            while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, len);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);

            }

        }
    }
}

