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

namespace ToDOList
{
  public class ToDo
    {
      [PrimaryKey,AutoIncrement]
      public int ListId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }

        public ToDo()
        {

        }

    }
}