using Android;
using Android.App;
using Android.Views;
using Android.Widget;
using MyWorkoutPal.Model;
using System.Collections.Generic;
namespace MyWokoutPal.Model
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtSets { get; set; }
        public TextView txtReps { get; set; }
        public TextView txtEmail { get; set; }
    }

    public class ListViewAdapterInfo : BaseAdapter
    {
        private Activity activity;
        private List<Info> listPerson;
        public ListViewAdapterInfo(Activity activity, List<Info> listPerson)
        {
            this.activity = activity;
            this.listPerson = listPerson;
        }
        public override int Count
        {
            get { return listPerson.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listPerson[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(MyWorkoutPal.Resource.Layout.list_view, parent, false);
            return view;
        }
    }

    public class ListViewAdapterWorkout : BaseAdapter
    {
        private Activity activity;
        private List<Workout> listPerson;
        public ListViewAdapterWorkout(Activity activity, List<Workout> listPerson)
        {
            this.activity = activity;
            this.listPerson = listPerson;
        }
        public override int Count
        {
            get { return listPerson.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listPerson[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(MyWorkoutPal.Resource.Layout.list_view, parent, false);
            return view;
        }
    }

    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Exercise> listPerson;
        public ListViewAdapter(Activity activity, List<Exercise> listPerson)
        {
            this.activity = activity;
            this.listPerson = listPerson;
        }
        public override int Count
        {
            get { return listPerson.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listPerson[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(MyWorkoutPal.Resource.Layout.list_view, parent, false);
            var txtName = view.FindViewById<TextView>(MyWorkoutPal.Resource.Id.txtView_Name);
            var txtSets = view.FindViewById<TextView>(MyWorkoutPal.Resource.Id.txtView_Sets);
            var txtReps = view.FindViewById<TextView>(MyWorkoutPal.Resource.Id.txtView_Reps);
            var txtEmail = view.FindViewById<TextView>(MyWorkoutPal.Resource.Id.txtView_Email);
            txtName.Text = listPerson[position].Name;
            txtSets.Text = listPerson[position].Sets;
            txtReps.Text = listPerson[position].Reps;
            txtEmail.Text = listPerson[position].Weight;
            return view;
        }
    }
}