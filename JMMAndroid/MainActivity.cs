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
using JMMAndroid.ImageManagement;

namespace JMMAndroid
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity
    {
        public static ImageDownloader imageHelper = null;
        public static AnimePluginSettings settings = null;

        public static string LastestVersion = string.Empty;
        public static DateTime NextVersionCheck = DateTime.Now;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}