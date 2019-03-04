using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NoteTakingApp
{
    [Activity(Label = "NoteTaking App",Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/Hello")]
   
    public class SplashScreen : Activity
    {
       // static readonly string TAG = "X:" + typeof(SplashActivity).Name;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));

            // Create your application here
        }

        
    }
}