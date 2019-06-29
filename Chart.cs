using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using MyWorkoutPal.Model;
using MyWorkoutPal.Resources.Helper;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace MyWorkoutPal
{
    [Activity(Label = "Chart")]
    public class Chart : Activity
    {
        List<Workout> listSourceWorkout = new List<Workout>();
        List<Info> listSourceInfo = new List<Info>();
        List<Exercise> listSource = new List<Exercise>();
        List<Graph> listSourceGraph = new List<Graph>();
        List<Exercise> listSourceNewChart = new List<Exercise>();
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {

                base.OnCreate(savedInstanceState);

                // Create your application here

                SetContentView(Resource.Layout.ChartLayout);

                var myLinearLayout = FindViewById<LinearLayout>(Resource.Id.myLinearLayout);

                ActionBar.Hide();

                var day = this.Intent.Extras.GetString("Day");

                //Create Database  
                db = new Database();
                db.createDatabase();
                db.createDatabaseInfo();

                //Load Data  
                LoadData();

                PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);

                view.Model = CreatePlotModel();


                var max = 999;

                TextView[] myChart = new TextView[max]; // create an empty array;



                listSource = db.selectTable().FindAll(Exercise => Exercise.Workout.Equals(day)); // This is just the data where the workout = whatever day was clicked

                for (int e = 0; e < max; e++)
                {
                    try
                    {
                        listSourceGraph = db.selectTableGraph().FindAll(Graph => Graph.Day.Equals(day) & Graph.Exercise.Equals(listSource[e].Name));
                    }
                    catch
                    {
                        break;
                    }

                    for (int nn = 0; nn < max; nn++)
                    {
                        try
                        {


                            //here just for now show a table of progress

                            // create a new button

                            TextView chartView = new TextView(this);

                            // set some properties of rowTextView or something
                            chartView.Text = "Exercise = " + listSourceGraph[nn].Exercise + ", Workout " + (nn + 1) + ", Weight = " + listSourceGraph[nn].Weight;

                            // add the textview to the linearlayout
                            myLinearLayout.AddView(chartView);

                            // save a reference to the button for later
                            myChart[nn] = chartView;




                        }
                        catch
                        {
                            Toast error = Toast.MakeText(this, nn + " Loops", ToastLength.Short);
                            error.Show();
                            break;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                error.Show();

            }

        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }

        private void LoadData()
        {
            listSourceInfo = db.selectTableInfo();
            listSourceWorkout = db.selectTableWorkout();
            var day = this.Intent.Extras.GetString("Day");

            listSource = db.selectTable().FindAll(Exercise => Exercise.Workout.Equals(day)); // This is just the data where the workout = whatever day was clicked
            listSourceGraph = db.selectTableGraph();
        }
    }
}