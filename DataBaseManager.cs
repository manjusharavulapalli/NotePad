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
using System.IO;


namespace NoteTakingApp
{
    public class DataBaseManager
    {
        static string dbName = "dbNotesList.sqlite";

        string dbpath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        public DataBaseManager()
        {

        }
        //Query All the records 
        public List<NoteRec> ViewAll()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbpath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "select * from tblNotesListData";
                    var NoteList = cmd.ExecuteQuery<NoteRec>();
                    return NoteList;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
                return null;
            }
        }

        //Updating Item to DataBase

        public void EditItem(String Details, int noteid)
        {
            String text;
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbpath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    text = "update tblNotesListData set Date='" + DateTime.Now + "',Details='" + Details + "' where NotedId=" + noteid;
                    Console.Write(text);

                    cmd.CommandText = text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Ocuured", e.Message);
            }

        }

        //Adding Item to DataBase
        public void AddItem(String Titel, String Details)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbpath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                
                    cmd.CommandText = "Insert into tblNotesListData(Title,Details) values('" + Titel + "','" + Details + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Ocuured", e.Message);
                
            }

        }

        //Deleting Item to DataBase
        public void DeleteItem(int noteid)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbpath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "delete from tblNotesListData where NotedId=" + noteid;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Ocuured", e.Message);
            }

        }
    }
   
}