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

namespace MyWorkoutPal
{
    [Activity(Label = "WorkoutFiller")]
    public class WorkoutFiller : Activity
    {
        List<Exercise> listSource = new List<Exercise>();
        List<Info> listSourceInfo = new List<Info>();
        Database db;
        int nDays = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.WorkoutFillerContent);

            ActionBar.Hide();


            //Create Database  
            db = new Database();
            db.createDatabase();

            //Load Data  
            LoadData();

            var days = listSourceInfo[0].Days;

            //TESTING SETS

            //Change listsource

            nDays = days; // total number of textviews to add

            TextView[] myTextViews = new TextView[nDays]; // create an empty array;

            try
            {

                for (int i = 0; i < nDays; i++)
                {
                    var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.dontUse);

                    // create a new textview
                    TextView rowTextView = new TextView(this);

                    // set some properties of rowTextView or something
                    rowTextView.Text = "Day " + (i + 1);

                    // add the textview to the linearlayout
                    myLinearLayout.AddView(rowTextView);

                    // save a reference to the textview for later
                    myTextViews[i] = rowTextView;
                }
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                error.Show();

            }
        }

        private void LoadData()
        {
            listSource = db.selectTable();
            listSourceInfo = db.selectTableInfo();
        }
    }
}