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
using SQLite;

namespace NoteTakingApp
{
  public class NoteRec
    {
        [PrimaryKey,AutoIncrement]
        public int NotedId { get; set; }
        public string Title { set; get; }
        public string Details { set; get; }
        public DateTime Date { set; get; }
    }
}