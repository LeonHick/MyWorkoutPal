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
using MyWorkoutPal.Resources.Helper;
using MyWorkoutPal.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MyWorkoutPal
{
    [Activity(Label = "MyWorkoutPal", MainLauncher = false, Theme = "@style/LogInActionBarTheme")]
    public class ProgramHome : Activity
    {
        List<Workout> listSourceWorkout = new List<Workout>();
        List<Info> listSourceInfo = new List<Info>();
        List<Exercise> listSource = new List<Exercise>();
        List<Graph> listSourceGraph = new List<Graph>();
        List<Exercise> listSourceNewChart = new List<Exercise>();

        Database db;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.ProgramHomeLayout);

            ActionBar.Hide();


            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);

            button1.Click += async delegate
            {
                runWorkout();
            };

            button2.Click += async delegate
            {
                runChart();
            };

            button3.Click += async delegate
            {
                runEdit();
            };

            button4.Click += async delegate
            {
                runAccount();
            };

            //Create Database  
            db = new Database();
            db.createDatabase();
            db.createDatabaseInfo();

            //Load Data  
            LoadData();

            string test = "";

            

            // Testing new layout

            Toast testToast = Toast.MakeText(this, listSourceInfo[0].Workout + " & " + listSourceInfo[0].Days, ToastLength.Short);
            testToast.Show();

            int n = listSourceInfo[0].Days;
            Button[] myButtons = new Button[n]; // create an empty array;

            var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.LinearTest);

            try
            {


                runEdit();


            }
            catch
            {
                Toast error = Toast.MakeText(this, "long", ToastLength.Short);
                error.Show();
            }



        }
        private void LoadData()
        {
            listSourceInfo = db.selectTableInfo();
            listSourceWorkout = db.selectTableWorkout();
            listSource = db.selectTable();
            listSourceGraph = db.selectTableGraph();
        }

        private void runWorkout()
        {
            LoadData();

            var title = FindViewById<TextView>(Resource.Id.toolbar_title);
            title.Text = listSourceInfo[0].Workout + ": Workout";
            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);

            button1.SetAlpha(255);
            button2.SetAlpha(55);
            button3.SetAlpha(55);
            button4.SetAlpha(55);

            var scale = (float)1.5;

            button1.ScaleX = scale;
            button1.ScaleY = scale;

            button2.ScaleX = 1;
            button2.ScaleY = 1;

            button3.ScaleX = 1;
            button3.ScaleY = 1;

            button4.ScaleX = 1;
            button4.ScaleY = 1;

            int n = listSourceInfo[0].Days;
            Button[] myButtons = new Button[n]; // create an empty array;

            var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.LinearTest);

            // remove previous views
            myLinearLayout.RemoveAllViews();

            for (int i = 0; i < n; i++)
            {
                // create a new button
                Button rowButton = new Button(this);

                // set some properties of rowTextView or something
                rowButton.Text = listSourceWorkout[i].Day + ": Workout!";

                // set the id of the buttons

                rowButton.Id = i;

                // add the textview to the linearlayout
                myLinearLayout.AddView(rowButton);

                // save a reference to the button for later
                myButtons[i] = rowButton;

                rowButton.Click += async delegate
                {
                    var ID = rowButton.Id;

                    try
                    {
                        var day = listSourceWorkout[ID].Day;

                        listSource = db.selectTable().FindAll(Exercise => Exercise.Workout.Equals(day)); // This is just the data where the workout = whatever day was clicked

                        var testeroo = listSource[0].Name;

                        var bundle = new Bundle();
                        bundle.PutString("Day", listSourceWorkout[ID].Day);

                        var intent = new Intent(this, typeof(PushWorkout));
                        intent.PutExtras(bundle);

                        this.StartActivity(intent);

                    }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, "Create a Workout First", ToastLength.Short);
                        error.Show();

                    }


                };
            }
        }

        private void runAccount()
        {
            var title = FindViewById<TextView>(Resource.Id.toolbar_title);
            title.Text = "Account";

            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);


            button1.SetAlpha(55);
            button2.SetAlpha(55);
            button3.SetAlpha(55);
            button4.SetAlpha(255);

            var scale = (float)1.5;

            button1.ScaleX = 1;
            button1.ScaleY = 1;

            button2.ScaleX = 1;
            button2.ScaleY = 1;

            button3.ScaleX = 1;
            button3.ScaleY = 1;

            button4.ScaleX = scale;
            button4.ScaleY = scale ;

            var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.LinearTest);

            // remove previous views
            myLinearLayout.RemoveAllViews();


            // create a new button
            Button editProfile = new Button(this);

            // set some properties of rowTextView or something
            editProfile.Text = "Edit Profile";

            // add the textview to the linearlayout
            myLinearLayout.AddView(editProfile);

            // create a new button
            Button editWorkout = new Button(this);

            // set some properties of rowTextView or something
            editWorkout.Text = "Edit Workout";

            // add the textview to the linearlayout
            myLinearLayout.AddView(editWorkout);

            editProfile.Click += async delegate
            {
                // remove previous views
                myLinearLayout.RemoveView(editWorkout);

                // create a new button
                EditText username = new EditText(this);

                // set some properties of rowTextView or something
                username.Hint = "Username";

                // add the textview to the linearlayout
                myLinearLayout.AddView(username);

                // create a new button
                EditText password = new EditText(this);

                // set some properties of rowTextView or something
                password.Hint = "Password";

                // add the textview to the linearlayout
                myLinearLayout.AddView(password);


                // create a new button
                Button done = new Button(this);

                // set some properties of rowTextView or something
                done.Text = "Done";

                // add the textview to the linearlayout
                myLinearLayout.AddView(done);

                // create a new button
                Button cancel = new Button(this);

                // set some properties of rowTextView or something
                cancel.Text = "Cancel";

                // add the textview to the linearlayout
                myLinearLayout.AddView(cancel);

                cancel.Click += async delegate
                 {
                     runAccount();
                 };

                done.Click += async delegate
                {
                    try
                    {

                        Info info = new Info()
                        {
                            Id = listSourceInfo[0].Id,
                            Name = username.Text,
                            Username = username.Text,
                            Password = password.Text,
                            Workout = listSourceInfo[0].Workout,
                            Days = listSourceInfo[0].Days
                        };

                        db.updateTableInfo(info);
                        LoadData();

                        Toast error = Toast.MakeText(this, listSourceInfo[0].Name + ": Your Changes Have Been Saved", ToastLength.Short);
                        error.Show();
                    }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                        error.Show();

                    }

                    runAccount();

                };

                
            };

            editWorkout.Click += async delegate
            {
                // remove previous views
                myLinearLayout.RemoveView(editProfile);

                // create a new button
                EditText planNameEdit = new EditText(this);

                // set some properties of rowTextView or something
                planNameEdit.Hint = "Plan Name";

                // add the textview to the linearlayout
                myLinearLayout.AddView(planNameEdit);

                // create a new button
                EditText daysEdit = new EditText(this);

                // set some properties of rowTextView or something
                daysEdit.Hint = "How Many Days?";

                // add the textview to the linearlayout
                myLinearLayout.AddView(daysEdit);

                // create a new button
                Button done = new Button(this);

                // set some properties of rowTextView or something
                done.Text = "Done";

                // add the textview to the linearlayout
                myLinearLayout.AddView(done);

                // create a new button
                Button finish = new Button(this);

                // set some properties of rowTextView or something
                finish.Text = "Save";

                // add the textview to the linearlayout
                myLinearLayout.AddView(finish);

                // create a new button
                Button cancel = new Button(this);

                // set some properties of rowTextView or something
                cancel.Text = "Cancel";

                // add the textview to the linearlayout
                myLinearLayout.AddView(cancel);

                cancel.Click += async delegate
                {
                    runAccount();
                };

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
                                Id = listSourceInfo[0].Id,
                                Name = listSourceInfo[0].Name,
                                Sex = listSourceInfo[0].Sex,
                                Weight = listSourceInfo[0].Weight,
                                Username = listSourceInfo[0].Name,
                                Password = listSourceInfo[0].Password,
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
                                                Toast error = Toast.MakeText(this, "There's Something Wrong", ToastLength.Short);
                                                error.Show();
                                            }
                                        }

                                    }


                                    if (full == true)
                                    {
                                        db.updateTableInfo(info);

                                        Toast update = Toast.MakeText(this, "Workout Added", ToastLength.Short);
                                        update.Show();

                                        runAccount();
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

            };

        }

        private void runChart()
        {
            var title = FindViewById<TextView>(Resource.Id.toolbar_title);
            title.Text = "Progress";

            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);


            button1.SetAlpha(55);
            button2.SetAlpha(255);
            button3.SetAlpha(55);
            button4.SetAlpha(55);

            var scale = (float)1.5;

            button1.ScaleX = 1;
            button1.ScaleY = 1;

            button2.ScaleX = scale;
            button2.ScaleY = scale;

            button3.ScaleX = 1;
            button3.ScaleY = 1;

            button4.ScaleX = 1;
            button4.ScaleY = 1;

            var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.LinearTest);

            // remove previous views
            myLinearLayout.RemoveAllViews();

            int n = listSourceInfo[0].Days;
            Button[] myButtons = new Button[n]; // create an empty array;

            // remove previous views
            myLinearLayout.RemoveAllViews();

            for (int i = 0; i < n; i++)
            {
                // create a new button
                Button rowButton = new Button(this);

                // set some properties of rowTextView or something
                rowButton.Text = listSourceWorkout[i].Day + ": View Progress";

                // set the id of the buttons

                rowButton.Id = i;

                // add the textview to the linearlayout
                myLinearLayout.AddView(rowButton);

                // save a reference to the button for later
                myButtons[i] = rowButton;

                rowButton.Click += async delegate
                {

                    try
                    {

                        var ID = rowButton.Id;

                        var day = listSourceWorkout[ID].Day;


                        var bundle = new Bundle();
                        bundle.PutString("Day", listSourceWorkout[ID].Day);

                        var intent = new Intent(this, typeof(Chart));
                        intent.PutExtras(bundle);

                        this.StartActivity(intent);
                    }
                    catch
                    {

                    }

                };
            }

        }

        private void runEdit()
        {
            LoadData();

            var title = FindViewById<TextView>(Resource.Id.toolbar_title);
            title.Text = listSourceInfo[0].Workout + ": Edit";

            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);


            button1.SetAlpha(55);
            button2.SetAlpha(55);
            button3.SetAlpha(255);
            button4.SetAlpha(55);

            var scale = (float)1.5;

            button1.ScaleX = 1;
            button1.ScaleY = 1;

            button2.ScaleX = 1;
            button2.ScaleY = 1;

            button3.ScaleX = scale;
            button3.ScaleY = scale;

            button4.ScaleX = 1;
            button4.ScaleY = 1;

            int n = listSourceInfo[0].Days;
            Button[] myButtons = new Button[n]; // create an empty array;

            var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.LinearTest);

            // remove previous views
            myLinearLayout.RemoveAllViews();

            for (int i = 0; i < n; i++)
            {

                // create a new button
                Button rowButton = new Button(this);

                // set some properties of rowTextView or something
                rowButton.Text = listSourceWorkout[i].Day + ": Edit";

                // set the id of the buttons

                rowButton.Id = i;

                // add the textview to the linearlayout
                myLinearLayout.AddView(rowButton);

                // save a reference to the button for later
                myButtons[i] = rowButton;



                rowButton.Click += async delegate
                {
                    var ID = rowButton.Id;

                    try
                    {
                        var bundle = new Bundle();
                        bundle.PutString("Day", listSourceWorkout[ID].Day);
                        var intent = new Intent(this, typeof(PushEditor));
                        intent.PutExtras(bundle);

                        this.StartActivity(intent);
                    }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                        error.Show();

                    }

                };
            }
        }

        private void reSize()
        {
            var button1 = FindViewById<ImageButton>(Resource.Id.taskbar1);
            var button2 = FindViewById<ImageButton>(Resource.Id.taskbar2);
            var button3 = FindViewById<ImageButton>(Resource.Id.taskbar3);
            var button4 = FindViewById<ImageButton>(Resource.Id.taskbar4);

            button1.SetAlpha(55);
            button2.SetAlpha(55);
            button3.SetAlpha(255);
            button4.SetAlpha(55);

            var scale = (float)1.5;

            button3.ScaleX = scale;
            button3.ScaleY = scale;
        }

    }
}