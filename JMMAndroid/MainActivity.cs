using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cornerstone.MP;
using JMMAndroid.ImageManagement;
using JMMAndroid.MultiSortLib;
using JMMAndroid.ViewModel;

namespace JMMAndroid
{
    [Activity(Label = "JMM - main view", MainLauncher =  true)]
    public class MainActivity : Activity
    {
        // Settings
        public static AnimePluginSettings settings = null;

        // Images

        public static ImageDownloader imageHelper = null;

        // Version checks
        public static string LastestVersion = string.Empty;
        public static DateTime NextVersionCheck = DateTime.Now;

        // Views
        public static View currentView = null;
        public static List<History> Breadcrumbs = new List<History>() { new History() };

        // Sorting
        Dictionary<int, QuickSort> GroupFilterQuickSorts = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            OnFirstStart();
            // Create your application here
        }

        private void OnFirstStart()
        {
            //bool authed = JMMServerVM.Instance.AuthenticateUser("Default", "");
            //Log.Debug("FirstStart", "Authenticated: " + authed);
            List<JMMUserVM> allUsers = JMMServerHelper.GetAllUsers();
            Log.Debug("FirstStart", "User count: " + allUsers.Count);

            //JMMServerVM.Instance.ServerStatusEvent += new JMMServerVM.ServerStatusEventHandler(Instance_ServerStatusEvent);
        }

    }
}