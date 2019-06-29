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

namespace MyWorkoutPal
{
    [Activity(Label = "Log In", Theme = "@style/LogInActionBarTheme")]
    public class Login : Activity
    {
        List<Info> listSource = new List<Info>();
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            try
            {

                SetContentView(Resource.Layout.Login_Content);

                ActionBar.Hide();

                //Create Database  
                db = new Database();
                db.createDatabaseInfo();

                //Load Data  
                LoadData();

                var progress = new Android.App.ProgressDialog(this);
                progress.Indeterminate = true;
                progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
                progress.SetMessage("Loading ...");
                progress.SetCancelable(true);
                progress.Hide();

                var done = FindViewById<Button>(Resource.Id.done);
                var namer = FindViewById<EditText>(Resource.Id.namer);
                var signup = FindViewById<Button>(Resource.Id.signup);
                var back = FindViewById<ImageButton>(Resource.Id.back);
                var passworder = FindViewById<EditText>(Resource.Id.passworder);

                if (namer.Text.Length == 0 || passworder.Text.Length == 0)
                {
                    done.SetBackgroundResource(Resource.Drawable.signInButtonLight);
                }

                namer.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
                {
                    if (namer.Text.Length > 0)
                    {
                        done.SetBackgroundResource(Resource.Drawable.signInButton);
                    }
                    else done.SetBackgroundResource(Resource.Drawable.signInButtonLight);
                };

                back.Click += delegate
                {
                    var intent = new Intent(this, typeof(IntroActivity));

                    var bundle1 = new Bundle();
                    intent.PutExtras(bundle1);

                    this.StartActivity(intent);
                };

                signup.Click += delegate
                {
                    var intent = new Intent(this, typeof(edit_profile_activity));

                    var bundle1 = new Bundle();
                    bundle1.PutString("comefrom", "login");
                    intent.PutExtras(bundle1);

                    this.StartActivity(intent);
                };

                done.Click += async delegate
                {
                    progress.Show();

                    try
                    {

                        string password = passworder.Text;
                        //password = password.Trim();

                        string name = namer.Text;
                        //name = name.Trim();


                        /*
                        ASCIIEncoding encoding = new ASCIIEncoding();
                        //string postData = "username" + user + "&password" + password;
                        

                    string info = "{\"name\""+":" + '"'+name+'"'+"}";
                    byte[] data = Encoding.ASCII.GetBytes(info);

                    WebRequest request = WebRequest.Create("http://51.140.38.46:8080/edit_profile_login");
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    string responseContent = null;

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader sr99 = new StreamReader(stream))
                            {
                                responseContent = sr99.ReadToEnd();

                                Toast resp = Toast.MakeText(this, responseContent, ToastLength.Long);
                                resp.Show();


                            }
                        }
                    }

                        if (responseContent == "Welcome back")
                        {


                            var intent = new Intent(this, typeof(Profile));

                            var bundle1 = new Bundle();
                            bundle1.PutString("namerText", name);
                            intent.PutExtras(bundle1);
                            this.StartActivity(intent);
                        
                        }/*
                        else { progress.Hide(); };

                }*/

                        try
                        {
                            string test = listSource[0].Name;

                            if (name == listSource[0].Name & password == listSource[0].Password)
                            {
                                try
                                {
                                    Toast resp = Toast.MakeText(this, "Welcome Back", ToastLength.Short);
                                    resp.Show();

                                    var intent = new Intent(this, typeof(ProgramHome));
                                    progress.Hide();
                                    this.StartActivity(intent);
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
                                    try
                                    {
                                        Toast resp = Toast.MakeText(this, "Username: " + listSource[0].Name + ", Password: " + listSource[0].Password, ToastLength.Short);
                                        resp.Show();
                                        progress.Hide();
                                    }
                                    catch (Exception e)
                                    {
                                        System.Exception myException = e;
                                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                                        error.Show();

                                    }
                            }

                        }
                        catch
                        {
                            Toast resp = Toast.MakeText(this, "Create an Account", ToastLength.Short);
                            resp.Show();
                            progress.Hide();
                        }


                        /*
                      else if (name != listSource[0].Name)
                      {
                          Toast resp = Toast.MakeText(this, "Unknown Username", ToastLength.Short);
                          resp.Show();
                      }
                      else if (password != listSource[0].Password)
                      {
                          Toast resp = Toast.MakeText(this, "Unknown Password", ToastLength.Short);
                          resp.Show();
                      }*/
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
        }
    }
}