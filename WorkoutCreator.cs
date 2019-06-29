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
    [Activity(Label = "WorkoutCreator")]
    public class WorkoutCreator : Activity
    {
        List<Info> listSource = new List<Info>();
        List<Workout> listSourceWorkout = new List<Workout>();
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            try
            {

                SetContentView(Resource.Layout.WorkoutCreatorContent);
                ActionBar.Hide();

                //Create Database  
                db = new Database();
                db.createDatabaseInfo();
                db.createDatabaseWorkout();

                //Load Data  
                LoadData();

                var planNameEdit = FindViewById<EditText>(Resource.Id.edtPlanName);
                var daysEdit = FindViewById<EditText>(Resource.Id.edtDays);
                var done = FindViewById<Button>(Resource.Id.done);
                var finish = FindViewById<Button>(Resource.Id.finished);

                finish.Visibility = ViewStates.Invisible;

                var planName = "";
                var days = "";

                done.Click += async delegate
                {
                    if (planNameEdit.Text.Length != 0 & daysEdit.Text.Length != 0)
                    {
                        planName = planNameEdit.Text;
                        days = daysEdit.Text;
                        finish.Visibility = ViewStates.Visible;

                        try
                        {
                            int daysInt = int.Parse(days);

                            Info info = new Info()
                            {
                                Id = listSource[0].Id,
                                Name = listSource[0].Name,
                                Sex = listSource[0].Sex,
                                Weight = listSource[0].Weight,
                                Username = listSource[0].Name,
                                Password = listSource[0].Password,
                                Bench = "0",
                                Squat = "0",
                                Dead = "0",
                                Ohp = "0",
                                BenchActual = "0",
                                SquatActual = "0",
                                DeadActual = "0",
                                OhpActual = "0",
                                Unit = "",
                                Month = "",
                                x = "",
                                Lower = "",
                                Upper = "",
                                Week = "",
                                Workout = planName,
                                Days = daysInt,
                            };

                            try
                            {
                                EditText[] myEditTexts = new EditText[daysInt]; // create an empty array;
                                var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.CreatorLayout);

                                // create a new textview
                                TextView Title = new TextView(this);

                                // set some properties of rowTextView or something
                                Title.Text = "Name Your Days";

                                // add the textview to the linearlayout
                                myLinearLayout.AddView(Title);

                                for (int i = 0; i < daysInt; i++)
                                {
                                    // create a new textview
                                    EditText rowEditText = new EditText(this);

                                    // set some properties of rowTextView or something
                                    rowEditText.Hint = "Day " + (i + 1);

                                    // add the textview to the linearlayout
                                    myLinearLayout.AddView(rowEditText);

                                    // save a reference to the textview for later
                                    myEditTexts[i] = rowEditText;

                                    
                                }
                            

                                finish.Click += async delegate
                                {
                                    var full = false;

                                    for (int i = 0; i < daysInt; i++)
                                    {
                                        if (myEditTexts[i].Text.Length != 0)
                                        {
                                            full = true;
                                            try
                                            {
                                                var test = listSourceWorkout[0].Day;

                                                Workout workout = new Workout()

                                                {
                                                    Id = listSourceWorkout[i].Id,
                                                    Day = myEditTexts[i].Text,
                                                };

                                                db.updateTableWorkout(workout);

                                                LoadData();

                                            }
                                            catch
                                            {

                                                Workout workout = new Workout()

                                                {
                                                    Id = i,
                                                    Day = myEditTexts[i].Text,
                                                };

                                                db.insertIntoTableWorkout(workout);

                                                LoadData();

                                                Toast error = Toast.MakeText(this, "it's trying to insert", ToastLength.Short);
                                                error.Show();
                                            }
                                        }
                                        
                                    }


                                    if (full == true)
                                    {
                                        db.updateTableInfo(info);

                                        Toast update = Toast.MakeText(this, "Workout Added", ToastLength.Short);
                                        update.Show();

                                        var intent = new Intent(this, typeof(ProgramHome));
                                        this.StartActivity(intent);
                                    }
                                    else
                                    {
                                        Toast error = Toast.MakeText(this, "Name All Your Days", ToastLength.Short);
                                        error.Show();
                                    }
                                };


                            }
                            catch (Exception e)
                            {
                                System.Exception myException = e;
                                Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                                error.Show();

                            }

                            
                        }

                        catch (Exception e)
                        {
                            System.Exception myException = e;
                            Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                            error.Show();
                        }

                    }
                    else
                    {
                        Toast idiot = Toast.MakeText(this, "Fill in all info", ToastLength.Short);
                        idiot.Show();
                    }
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
            listSource = db.selectTableInfo();
            listSourceWorkout = db.selectTableWorkout();
        }
    }
}