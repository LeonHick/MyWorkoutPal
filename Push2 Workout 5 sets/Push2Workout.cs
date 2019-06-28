using Android.App;
using Android.OS;
using Android.Widget;
using MyWorkoutPal.Resources.Helper;
using MyWorkoutPal.Model;
using System.Collections.Generic;
using Android.Content;
using System;

/* PLAN (BASIC)
 * 2) SET WORKOUT FOR EACH DAY
 * 3) CHOOSE WHAT WORKOUT IM DOING TODAY
 * 4) PUT IN WEIGHTS LIFTED
 * 5) IT TELLS YOU NEXT WEEK IF YOU NEED TO PUT WEIGHT UP
 * 
 * PLAN (COMMERCIAL)
 * */

namespace MyWorkoutPal
{
    [Activity(Label = "Push2Workout")]
    public class Push2Workout : Activity
    {
        List<Exercise> listSource = new List<Exercise>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.WorkoutLayout);
            var ex1 = FindViewById<TextView>(Resource.Id.Exercise1);
            var w1 = FindViewById<TextView>(Resource.Id.weight1);
            var w2 = FindViewById<TextView>(Resource.Id.weight2);
            var w3 = FindViewById<TextView>(Resource.Id.weight3);
            var w4 = FindViewById<TextView>(Resource.Id.weight4);
            var w5 = FindViewById<TextView>(Resource.Id.weight5);
            var done = FindViewById<TextView>(Resource.Id.done);

            var reps1 = FindViewById<TextView>(Resource.Id.reps1);
            var reps2 = FindViewById<TextView>(Resource.Id.reps2);
            var reps3 = FindViewById<TextView>(Resource.Id.reps3);
            var reps4 = FindViewById<EditText>(Resource.Id.reps4);
            var reps5 = FindViewById<EditText>(Resource.Id.reps5);

            var set1 = FindViewById<TextView>(Resource.Id.set1);
            var set2 = FindViewById<TextView>(Resource.Id.set2);
            var set3 = FindViewById<TextView>(Resource.Id.set3);
            var set4 = FindViewById<TextView>(Resource.Id.set4);
            var set5 = FindViewById<TextView>(Resource.Id.set5);

            //Create Database  
            db = new Database();
            db.createDatabasePush2();

            //Load Data  
            LoadData();

            var exercise1 = listSource[0].Name;
            var sets = listSource[0].Sets;
            var reps = listSource[0].Reps;
            var weight = listSource[0].Weight;

            ex1.Text = exercise1 + ", " + sets + " sets of " + reps;
            w1.Text = weight;
            w2.Text = weight;
            w3.Text = weight;
            w4.Text = weight;
            w5.Text = weight;

            reps1.Text = reps;
            reps2.Text = reps;
            reps3.Text = reps;

            set1.Text = "Set 1";
            set2.Text = "Set 2";
            set3.Text = "Set 3";
            set4.Text = "Set 4: " + reps + "+";
            set5.Text = "Set 5: " + reps + "?";

            var reps4String = "";
            var reps5String = "";
            var test = "";


            done.Click += async delegate
            {
                reps4String = reps4.Text;
                reps5String = reps5.Text;
                double reps4Int = int.Parse(reps4String);
                double reps5Int = int.Parse(reps5String);
                double repsInt = int.Parse(reps);
                double x = reps4Int - repsInt;
                double weightInt = double.Parse(weight);

                if (x >= 2)
                {

                    weightInt = (weightInt + 2.5);
                    weight = weightInt.ToString();
                    Exercise exercise = new Exercise()
                    {
                        Id = listSource[0].Id,
                        Name = exercise1,
                        Sets = sets,
                        Reps = reps,
                        Weight = weight
                    };
                    db.updateTablePush2(exercise);
                    LoadData();
                };

                if (x <= -2)
                {
                    weightInt = weightInt - 2.5;
                    weight = weightInt.ToString();
                    Exercise exercise = new Exercise()
                    {
                        Id = listSource[0].Id,
                        Name = exercise1,
                        Sets = sets,
                        Reps = reps,
                        Weight = weight
                    };
                    db.updateTablePush2(exercise);
                    LoadData();
                };

                try
                {
                    test = listSource[1].Name;
                    var intent = new Intent(this, typeof(Push2Workout2));
                    this.StartActivity(intent);
                }
                catch
                {
                    var intent = new Intent(this, typeof(ProgramHome));
                    this.StartActivity(intent);
                };

            };

        }
        private void LoadData()
        {
            listSource = db.selectTablePush2();
        }
    }
}