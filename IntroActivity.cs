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
using Android.Graphics;

//main launcher

namespace MyWorkoutPal
{
    [Activity(MainLauncher = true, Label = "MyWorkoutPal", Theme = "@style/CustomActionBarTheme")]
    public class IntroActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Intro);

            try
            {

                ActionBar.Hide();

                var signup = FindViewById<Button>(Resource.Id.signup);
                var login = FindViewById<Button>(Resource.Id.login);
                var intrologo = FindViewById<ImageView>(Resource.Id.intrologo);
                var imagewrapper = FindViewById<LinearLayout>(Resource.Id.imagewrapper);
                var title = FindViewById<TextView>(Resource.Id.appName);

                var metrics = Resources.DisplayMetrics;
                var width = metrics.WidthPixels;
                var height = metrics.HeightPixels;


                var widther = Math.Round(width / 2.5);
                var heighter = width / 2.75;
                int widthInt = Convert.ToInt32(widther);
                int heightInt = Convert.ToInt32(heighter);
                int x = width / 2;
                int y = widthInt / 2;

                imagewrapper.TranslationX = x - y;
                imagewrapper.TranslationY = height / 8;
                title.TranslationY = height / 6;
                signup.TranslationY = height / 3;
                login.TranslationY = height / 3;

                //title.Typeface = Typeface.CreateFromAsset(Assets, "fonts/samplefont.tff");

                LinearLayout.LayoutParams parms = new LinearLayout.LayoutParams(widthInt, heightInt); //Width, Height
                imagewrapper.LayoutParameters = parms;


                //ive fucked around here

                signup.Click += delegate
                {
                    var intent = new Intent(this, typeof(edit_profile_activity));

                    var bundle1 = new Bundle();
                    bundle1.PutString("comefrom", "intro");
                    intent.PutExtras(bundle1);

                    this.StartActivity(intent);
                };

                login.Click += delegate
                {
                    var intent = new Intent(this, typeof(Login));
                    this.StartActivity(intent);
                };
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