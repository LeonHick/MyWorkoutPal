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
using System.Net;
using System.IO;
using Android.Graphics;
using Android.Views;
using MyWorkoutPal.Model;
using MyWorkoutPal.Resources.Helper;
using MyWokoutPal.Model;

namespace MyWorkoutPal
{
    [Activity(Label = "WorkoutSelecter", Theme = "@style/LogInActionBarTheme")]
    public class WorkoutSelecter : Activity
    {
        List<Info> listSource = new List<Info>();
        ListView lstViewDataInfo;
        ListView lstViewDataWorkout;
        List<Workout> listSourceWorkout = new List<Workout>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            try
            {

                SetContentView(Resource.Layout.WorkoutSelecterLayout);
                
                ActionBar.Hide();

                //Create Database  
                db = new Database();
                db.createDatabaseInfo();
                db.createDatabaseWorkout();

                //Load Data  
                LoadData();

                var create = FindViewById<Button>(Resource.Id.create);
                var PPLPPL = FindViewById<Button>(Resource.Id.PPLPPL);
                
                create.Click += async delegate
                {
                    try
                    {
                        var intent = new Intent(this, typeof(WorkoutCreator));

                        this.StartActivity(intent);
                    }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                        error.Show();
                    }
                };

                PPLPPL.Click += async delegate
                {
                    try
                    {
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
                            Workout = "PPLPPL",
                            Days = 5
                        };

                        db.updateTableInfo(info);

                        try
                        {
                            var test = listSourceWorkout[0].Day;

                            Toast toast = Toast.MakeText(this, "before " + listSourceWorkout[0].Id + " " + test, ToastLength.Short);
                            toast.Show();

                            Workout workout = new Workout()

                            {
                                Id = listSourceWorkout[0].Id,
                                Day = "Push"
                            };

                            db.updateTableWorkout(workout);
                            LoadData();
                            Toast toast2 = Toast.MakeText(this, "after " + listSourceWorkout[0].Id + " " + listSourceWorkout[0].Day, ToastLength.Short);
                            toast2.Show();
                        }
                        catch
                        {

                            Workout workout = new Workout()

                            {
                                Id = 0,
                                Day = "Push"
                            };

                            db.insertIntoTableWorkout(workout);
                        }

                        try
                        {
                            var test = listSourceWorkout[1].Day;

                            Workout workout2= new Workout()

                            {
                                Id = listSourceWorkout[1].Id,
                                Day = "Pull"
                            };

                            db.updateTableWorkout(workout2);
                        }
                        catch
                        {

                            Workout workout2 = new Workout()

                            {
                                Id = 1,
                                Day = "Pull"
                            };

                            db.insertIntoTableWorkout(workout2);
                        }
                        try
                        {
                            var test = listSourceWorkout[2].Day;

                            Workout workout3 = new Workout()

                            {
                                Id = listSourceWorkout[2].Id,
                                Day = "Push2"
                            };

                            db.updateTableWorkout(workout3);
                        }
                        catch
                        {

                            Workout workout3 = new Workout()

                            {
                                Id = 2,
                                Day = "Push2"
                            };

                            db.insertIntoTableWorkout(workout3);
                        }
                        try
                        {
                            var test = listSourceWorkout[3].Day;

                            Workout workout4 = new Workout()

                            {
                                Id = listSourceWorkout[3].Id,
                                Day = "Pull2"
                            };

                            db.updateTableWorkout(workout4);
                        }
                        catch
                        {

                            Workout workout4 = new Workout()

                            {
                                Id = 3,
                                Day = "Pull2"
                            };

                            db.insertIntoTableWorkout(workout4);
                        }
                        try
                        {
                            var test = listSourceWorkout[4].Day;

                            Workout workout5 = new Workout()

                            {
                                Id = listSourceWorkout[4].Id,
                                Day = "Legs"
                            };

                            db.updateTableWorkout(workout5);
                        }
                        catch
                        {

                            Workout workout5 = new Workout()

                            {
                                Id = 4,
                                Day = "Legs"
                            };

                            db.insertIntoTableWorkout(workout5);
                        }


                        LoadData();

                        Toast resp = Toast.MakeText(this, "Workout " + listSource[0].Workout+ " Saved", ToastLength.Short);
                        resp.Show();

                        var intent = new Intent(this, typeof(ProgramHome));
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
            /*
            var adapter = new ListViewAdapterInfo(this, listSource);
            var adapterWorkout = new ListViewAdapterWorkout(this, listSourceWorkout);

            lstViewDataInfo.Adapter = adapter;
            lstViewDataWorkout.Adapter = adapterWorkout;*/
        }
    }
}
