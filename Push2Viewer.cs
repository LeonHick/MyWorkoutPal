using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.App;
using Android.OS;
using Android.Widget;
using MyWorkoutPal.Resources.Helper;
using MyWorkoutPal.Model;
using System.Collections.Generic;
using Android.Content;

namespace MyWorkoutPal
{
    [Activity(Label = "Push2Viewer", Theme = "@style/LogInActionBarTheme")]
    public class Push2Viewer : Activity
    {
        ListView lstViewData;
        List<Exercise> listSource = new List<Exercise>();
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.PushViewerLayout);

            ActionBar.Hide();

            lstViewData = FindViewById<ListView>(Resource.Id.listView);

            db = new Database();
            db.createDatabase();
            //Load Data  
            LoadData();
        }

        private void LoadData()
        {
            listSource = db.selectTablePush2();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}