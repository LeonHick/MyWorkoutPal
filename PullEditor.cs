using Android.App;
using Android.OS;
using Android.Widget;
using MyWorkoutPal.Resources.Helper;
using MyWorkoutPal.Model;
using System.Collections.Generic;
using Android.Content;

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
    [Activity(Label = "PullEditor", Theme = "@style/LogInActionBarTheme")]
    public class PullEditor : Activity
    {
        ListView lstViewData;
        List<Exercise> listSource = new List<Exercise>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Main);

            ActionBar.Hide();

            //Create Database  
            db = new Database();
            db.createDatabasePull();
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtSets = FindViewById<EditText>(Resource.Id.edtSets);
            var edtReps = FindViewById<EditText>(Resource.Id.edtReps);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            //Load Data  
            LoadData();
            //Event  
            btnAdd.Click += delegate
            {
                Exercise exercise = new Exercise()
                {
                    Workout = "Pull",
                    Name = edtName.Text,
                    Sets = edtSets.Text,
                    Reps = edtReps.Text,
                    Weight = edtEmail.Text
                };
                db.insertIntoTablePull(exercise);
                LoadData();
            };
            btnEdit.Click += delegate
            {
                Exercise exercise = new Exercise()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Workout = "Pull",
                    Name = edtName.Text,
                    Sets = edtSets.Text,
                    Reps = edtReps.Text,
                    Weight = edtEmail.Text
                };
                db.updateTablePull(exercise);
                LoadData();
            };
            btnRemove.Click += delegate
            {
                Exercise exercise = new Exercise()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Workout = "Pull",
                    Name = edtName.Text,
                    Sets = edtSets.Text,
                    Reps = edtReps.Text,
                    Weight = edtEmail.Text
                };
                db.removeTablePull(exercise);
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
                edtEmail.Text = txtName.Text;
                edtName.Tag = e.Id;
                edtSets.Text = "Sets: " + txtSets.Text;
                edtReps.Text = "Reps: " + txtReps.Text;
                edtEmail.Text = "Weight: " + txtEmail.Text;
            };

            var done = FindViewById<Button>(Resource.Id.done);

            done.Click += async delegate
            {
                var intent = new Intent(this, typeof(ProgramHome));

                this.StartActivity(intent);

            };


        }
        private void LoadData()
        {
            listSource = db.selectTablePull();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}


