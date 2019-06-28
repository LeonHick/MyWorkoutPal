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
using MyWorkoutPal.Model;
using MyWorkoutPal.Resources.Helper;

namespace MyWorkoutPal.WorkoutIntros
{
    [Activity(Label = "_1ExerciseContent")]
    public class _1ExerciseContent : Activity
    {
        ListView lstViewData;
        List<Exercise> listSourcePush = new List<Exercise>();
        List<Exercise> listSourcePush2 = new List<Exercise>();
        List<Exercise> listSourcePull = new List<Exercise>();
        List<Exercise> listSourcePull2 = new List<Exercise>();
        List<Exercise> listSourceLegs = new List<Exercise>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Main);
            //Create Database  
            db = new Database();
            db.createDatabaseLegs();
            //Load Data  
            LoadData();
        }

        private void LoadData()
        {
            listSourcePush = db.selectTable();
            listSourcePush2 = db.selectTablePush2();
            listSourcePull = db.selectTablePull();
            listSourcePull2 = db.selectTablePull2();
            listSourceLegs = db.selectTableLegs();
            var adapter = new ListViewAdapter(this, listSourcePush);
            lstViewData.Adapter = adapter;
        }
    }


}