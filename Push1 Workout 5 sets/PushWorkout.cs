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
    [Activity(Label = "PushWorkout", Theme = "@style/LogInActionBarTheme")]
    public class PushWorkout : Activity
    {
        List<Exercise> listSource = new List<Exercise>();
        List<Graph> listSourceGraph = new List<Graph>();
        Database db;

        string sets = "" + 10;
        string reps = "" + 20;
        string weight = "" + 100;
        string exercise1 = "Bench";
        int id = 0;
        int nEx = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                var day = this.Intent.Extras.GetString("Day");

                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource  
                SetContentView(Resource.Layout.WorkoutLayoutNew);

                ActionBar.Hide();

                var ex1 = FindViewById<TextView>(Resource.Id.Exercise1);
                var w4 = FindViewById<TextView>(Resource.Id.weight4);
                var w5 = FindViewById<TextView>(Resource.Id.weight5);
                var done = FindViewById<TextView>(Resource.Id.done);

                var reps4 = FindViewById<EditText>(Resource.Id.reps4);
                var reps5 = FindViewById<EditText>(Resource.Id.reps5);

                //Create Database  
                db = new Database();
                db.createDatabase();
                db.createDatabaseGraph();

                //Load Data  
                LoadData();

                //TESTING SETS

                //Change listsource

                Reset();
                

                    int n = int.Parse(sets) - 2;
                    int nn = int.Parse(sets) - 1;
                    int N = int.Parse(sets); // total number of textviews to add
                TextView[] myTextViews = new TextView[N]; // create an empty array;

                try
                {

                    

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
                }
                catch
                {
                    Toast error = Toast.MakeText(this, "long", ToastLength.Short);
                    error.Show();
                }
                try
                    {

                    
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

                }

                catch
                {
                    Toast error = Toast.MakeText(this, "shortcuts", ToastLength.Short);
                    error.Show();
                }

                ex1.Text = exercise1 + ", " + sets + " sets of " + reps;
                w4.Text = " reps of " + weight + "kg";
                w5.Text = " reps of " + weight + "kg";


                var reps4String = "";
                var reps5String = "";
                var test = "";


                done.Click += async delegate
                {
                    
                    reps4String = reps4.Text;
                    reps5String = reps5.Text;

                    if (reps4String.Length == 0 & reps5String.Length == 0)
                    {
                        Toast error = Toast.MakeText(this, "Enter value for working sets", ToastLength.Short);
                        error.Show();
                    }

                    if (reps4String.Length == 0 & reps5String.Length != 0)
                    {
                        Toast error = Toast.MakeText(this, "Enter value for AMRAP set", ToastLength.Short);
                        error.Show();
                    }

                    if (reps4String.Length != 0 & reps5String.Length == 0)
                    {
                        Toast error = Toast.MakeText(this, "Enter value for final set", ToastLength.Short);
                        error.Show();
                    }

                    if (reps4String.Length != 0 & reps5String.Length != 0)
                    {

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
                                Id = listSource[id].Id,
                                Workout = listSource[id].Workout,
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
                                Id = listSource[id].Id,
                                Workout = listSource[id].Workout,
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
                            var max = 999;

                            for (int i = 0; i < max; i++)
                            {
                                try
                                {
                                    var testGraph = listSourceGraph[i].Id;
                                }
                                catch
                                {

                                    Graph graph = new Graph()
                                    {
                                        Id = i,
                                        Workout = listSource[id].Workout,
                                        Day = day,
                                        Weight = weight,
                                        Exercise = exercise1
                                    };
                                    db.insertIntoTableGraph(graph);
                                    LoadData();

                                    Toast error = Toast.MakeText(this, "Graph " + i + " Insterted", ToastLength.Short);
                                    error.Show();

                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            System.Exception myException = e;
                            Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                            error.Show();

                        }

                        try
                        {
                            // go to next exercise

                            ++nEx;

                            // test if next exercise exists

                            test = listSource[nEx].Name;

                            ReRun();

                            Toast success = Toast.MakeText(this,"" + nEx, ToastLength.Short);
                            success.Show();
                        }
                        catch
                        {
                            var intent = new Intent(this, typeof(ProgramHome));
                            this.StartActivity(intent);
                        };


                    };
                };
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, "Main bulk " + e.Message, ToastLength.Short);
                error.Show();

            }

        }

        private void Reset()
        {
            try
            {
                reps = listSource[nEx].Reps;
                weight = listSource[nEx].Weight;
                exercise1 = listSource[nEx].Name;
                id = nEx;
                sets = listSource[nEx].Sets;
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, "Main bulk " + e.Message, ToastLength.Short);
                error.Show();

            }
        }

        private void ReRun()
        {
            try
            {
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

                //Change listsource

                Reset();


                int n = int.Parse(sets) - 2;
                int nn = int.Parse(sets) - 1;
                int N = int.Parse(sets); // total number of textviews to add
                TextView[] myTextViews = new TextView[N]; // create an empty array;

                var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.PreSetLayout);
                var myLinearLayout2 = FindViewById<LinearLayout>(Resource.Id.PostSetLayout);

                // remove previous views

                myLinearLayout.RemoveAllViews();
                myLinearLayout2.RemoveAllViews();

                // reset textBoxes

                reps4.Text = "";
                reps5.Text = "";

                try
                {

                    for (int i = 0; i < n; i++)
                    {
                        
                        // create a new textview
                        TextView rowTextView = new TextView(this);

                        // set some properties of rowTextView or something
                        rowTextView.Text = "Set " + (i + 1) + ": " + reps + " reps of " + weight + "kg";

                        // add the textview to the linearlayout
                        myLinearLayout.AddView(rowTextView);

                        // save a reference to the textview for later
                        myTextViews[i] = rowTextView;
                    }
                }
                catch
                {
                    Toast error = Toast.MakeText(this, "long", ToastLength.Short);
                    error.Show();
                }
                try
                {


                    for (int i = n; i < nn; i++)
                    {
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

                        // create a new textview
                        TextView rowTextView = new TextView(this);

                        // set some properties of rowTextView or something
                        rowTextView.Text = "Set " + (i + 1) + ": " + reps + "? reps of " + weight + "kg";

                        // add the textview to the linearlayout
                        myLinearLayout2.AddView(rowTextView);

                        // save a reference to the textview for later
                        myTextViews[i] = rowTextView;
                    }

                }

                catch
                {
                    Toast error = Toast.MakeText(this, "shortcuts", ToastLength.Short);
                    error.Show();
                }

                ex1.Text = exercise1 + ", " + sets + " sets of " + reps;
                w4.Text = " reps of " + weight + "kg";
                w5.Text = " reps of " + weight + "kg";
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, "Main bulk " + e.Message, ToastLength.Short);
                error.Show();

            }
        }

        private void LoadData()
        {
            try
            {
                var day = this.Intent.Extras.GetString("Day");

                listSource = db.selectTable().FindAll(Exercise => Exercise.Workout.Equals(day)); // This is just the data where the workout = whatever day was clicked
                listSourceGraph = db.selectTableGraph();
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