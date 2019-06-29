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
    [Activity(Label = "PushEditor", Theme = "@style/LogInActionBarTheme")]
    public class PushEditor : Activity
    {
        ListView lstViewData;
        List<Exercise> listSource = new List<Exercise>();
        List<Workout> listSourceWorkout = new List<Workout>();
        List<Info> listSourceInfo = new List<Info>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {

                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource  
                SetContentView(Resource.Layout.Main);

                var day = this.Intent.Extras.GetString("Day");

                ActionBar.Hide();

                //Create Database  
                db = new Database();
                db.createDatabase();

                lstViewData = FindViewById<ListView>(Resource.Id.listView);

                var edtName = FindViewById<EditText>(Resource.Id.edtName);
                var edtSets = FindViewById<EditText>(Resource.Id.edtSets);
                var edtReps = FindViewById<EditText>(Resource.Id.edtReps);
                var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
                var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
                var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
                var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
                var title = FindViewById<TextView>(Resource.Id.toolbar_title);

                //Load Data  
                LoadData();

                title.Text = day;

                try
                {

                    Toast error = Toast.MakeText(this, listSource[0].Name, ToastLength.Short);
                    error.Show();
                }
                catch
                {
                    Toast error = Toast.MakeText(this, "none yet", ToastLength.Short);
                    error.Show();

                }

                //Event  
                btnAdd.Click += delegate
                {
                    Exercise exercise = new Exercise()
                    {
                        Workout = day,
                        Name = edtName.Text,
                        Sets = "10",
                        Reps = edtReps.Text,
                        Weight = edtEmail.Text
                    };

                    db.insertIntoTable(exercise);

                    LoadData();

                    try
                    {
                        Toast error = Toast.MakeText(this, listSource[0].Workout, ToastLength.Short);
                        error.Show();
                    }
                    catch
                    {
                        Toast error = Toast.MakeText(this, "Workout Error", ToastLength.Short);
                        error.Show();
                    }

                    try
                    {
                        Toast error = Toast.MakeText(this, listSource[0].Name, ToastLength.Short);
                        error.Show();
                    }
                    catch
                    {
                        Toast error = Toast.MakeText(this, "Name Error", ToastLength.Short);
                        error.Show();
                    }

                    try
                    {
                        Toast error = Toast.MakeText(this, listSource[0].Reps, ToastLength.Short);
                        error.Show();
                    }
                    catch
                    {
                        Toast error = Toast.MakeText(this, "Reps Error", ToastLength.Short);
                        error.Show();
                    }

                    try
                    {
                        Toast error = Toast.MakeText(this, listSource[0].Weight, ToastLength.Short);
                        error.Show();
                    }
                    catch
                    {
                        Toast error = Toast.MakeText(this, "Weight Error", ToastLength.Short);
                        error.Show();
                    }

                    try
                    {
                        Toast error = Toast.MakeText(this, listSource[0].Sets, ToastLength.Short);
                        error.Show();
                    }
                    catch
                    {
                        Toast error = Toast.MakeText(this, "Sets Error", ToastLength.Short);
                        error.Show();
                    }

                };
                btnEdit.Click += delegate
                {
                    Exercise exercise = new Exercise()
                    {
                        Id = int.Parse(edtName.Tag.ToString()),
                        Workout = day,
                        Name = edtName.Text,
                        Sets = edtSets.Text,
                        Reps = edtReps.Text,
                        Weight = edtEmail.Text
                    };

                    db.updateTable(exercise);

                    LoadData();
                };
                btnRemove.Click += delegate
                {
                    Exercise exercise = new Exercise()
                    {
                        Id = int.Parse(edtName.Tag.ToString()),
                        Workout = day,
                        Name = edtName.Text,
                        Sets = edtSets.Text,
                        Reps = edtReps.Text,
                        Weight = edtEmail.Text
                    };

                    db.removeTable(exercise);

                    LoadData();
                };
                lstViewData.ItemClick += (s, e) =>
                {
                /*
                //Set Backround for selected item  
                for (int i = 0; i < lstViewData.Count; i++)
                {
                    if (e.Position == i)
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
                    else
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }*/
                //Binding Data  
                var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
                    var txtSets = e.View.FindViewById<TextView>(Resource.Id.txtView_Sets);
                    var txtReps = e.View.FindViewById<TextView>(Resource.Id.txtView_Reps);
                    var txtEmail = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
                    edtName.Text = txtName.Text;
                    edtName.Tag = e.Id;
                    edtSets.Text = txtSets.Text;
                    edtReps.Text = txtReps.Text;
                    edtEmail.Text = txtEmail.Text;
                };

                var done = FindViewById<Button>(Resource.Id.done);

                done.Click += async delegate
                {
                    var intent = new Intent(this, typeof(ProgramHome));

                    this.StartActivity(intent);

                };
            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, "Main Text Error: " + e.Message, ToastLength.Short);
                error.Show();

            }


        }
        private void LoadData()
        {
            try
            {
                var day = this.Intent.Extras.GetString("Day");

                listSourceWorkout = db.selectTableWorkout(); 
                listSource = db.selectTable().FindAll(Exercise => Exercise.Workout.Equals(day)); // This is just the data where the workout = whatever day was clicked
                listSourceInfo = db.selectTableInfo();

                var adapter = new ListViewAdapter(this, listSource);
                lstViewData.Adapter = adapter;

            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, "Load Data Error: " + e.Message, ToastLength.Short);
                error.Show();

            }
        }

       
    }
}



