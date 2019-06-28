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
    [Activity(Label = "PushWorkout3")]
    public class PushWorkout3 : Activity
    {
        List<Exercise> listSource = new List<Exercise>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {


                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource  
                SetContentView(Resource.Layout.WorkoutLayoutNew);

                var ex1 = FindViewById<TextView>(Resource.Id.Exercise1);
                var w4 = FindViewById<TextView>(Resource.Id.weight4);
                var w5 = FindViewById<TextView>(Resource.Id.weight5);
                var done = FindViewById<TextView>(Resource.Id.done);

                var reps4 = FindViewById<EditText>(Resource.Id.reps4);
                var reps5 = FindViewById<EditText>(Resource.Id.reps5);

                //Create Database  
                db = new Database();
                db.createDatabase();

                //Load Data  
                LoadData();

                //TESTING SETS

                var sets = listSource[2].Sets;
                var reps = listSource[2].Reps;
                var weight = listSource[2].Weight;
                var exercise1 = listSource[2].Name;
                var id = listSource[2].Id;

                int n = int.Parse(sets) - 2;
                int nn = int.Parse(sets) - 1;
                int N = int.Parse(sets); // total number of textviews to add

                TextView[] myTextViews = new TextView[N]; // create an empty array;

                for (int i = 0; i < n; i++)
                {
                    var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.PreSetLayout);

                    // create a new textview
                    TextView rowTextView = new TextView(this);

                    // set some properties of rowTextView or something
                    rowTextView.Text = "Set " + (i + 1) + ": " + reps + " reps of " + weight + "kg";

                    // add the textview to the linearlayout
                    myLinearLayout.AddView(rowTextView);

                    // save a reference to the textview for later
                    myTextViews[i] = rowTextView;
                }
                for (int i = n; i < nn; i++)
                {
                    var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.PreSetLayout);

                    // create a new textview
                    TextView rowTextView = new TextView(this);

                    // set some properties of rowTextView or something
                    rowTextView.Text = "Set " + (i + 1) + ": " + reps + "+ reps of " + weight + "kg";

                    // add the textview to the linearlayout
                    myLinearLayout.AddView(rowTextView);

                    // save a reference to the textview for later
                    myTextViews[i] = rowTextView;
                }

                for (int i = nn; i < N; i++)
                {
                    var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.PostSetLayout);

                    // create a new textview
                    TextView rowTextView = new TextView(this);

                    // set some properties of rowTextView or something
                    rowTextView.Text = "Set " + (i + 1) + ": " + reps + "? reps of " + weight + "kg";

                    // add the textview to the linearlayout
                    myLinearLayout.AddView(rowTextView);

                    // save a reference to the textview for later
                    myTextViews[i] = rowTextView;
                }



                ex1.Text = exercise1 + ", " + sets + " sets of " + reps;
                w4.Text = weight;
                w5.Text = weight;


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
                            Id = id,
                            Name = exercise1,
                            Sets = sets,
                            Reps = reps,
                            Weight = weight
                        };
                        db.updateTable(exercise);
                        LoadData();
                    };

                    if (x <= -2)
                    {
                        weightInt = weightInt - 2.5;
                        weight = weightInt.ToString();
                        Exercise exercise = new Exercise()
                        {
                            Id = id,
                            Name = exercise1,
                            Sets = sets,
                            Reps = reps,
                            Weight = weight
                        };
                        db.updateTable(exercise);
                        LoadData();
                    };

                    try
                    {
                        var workout = this.Intent.Extras.GetString("workout");
                        test = listSource[3].Name;

                        var bundle = new Bundle();
                        bundle.PutString("workout", workout);
                        var intent = new Intent(this, typeof(PushWorkout4));
                        intent.PutExtras(bundle);

                        this.StartActivity(intent);
                    }
                    catch
                    {
                        var intent = new Intent(this, typeof(ProgramHome));
                        this.StartActivity(intent);
                    };

                };
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
            try
            {

                var workout = this.Intent.Extras.GetString("workout");

                if (workout == "push")
                {
                    listSource = db.selectTable();
                }

                else if (workout == "push2")
                {
                    listSource = db.selectTablePush2();
                }

                else if (workout == "pull")
                {
                    listSource = db.selectTablePull();
                }

                else if (workout == "pull2")
                {
                    listSource = db.selectTablePull2();
                }

                else if (workout == "legs")
                {
                    listSource = db.selectTableLegs();
                }
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                error.Show();

            }
        }
    }
}