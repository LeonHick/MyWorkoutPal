using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Widget;
using MyWorkoutPal.Resources.Helper;
using MyWorkoutPal.Model;
using Android.Content;
using Android.Runtime;
using Android.Views;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.IO;

namespace MyWorkoutPal
{
    [Activity(Label = "PowerBuilder", Theme = "@style/CustomActionBarTheme")]
    public class edit_profile_activity : Activity
    {
        List<Info> listSource = new List<Info>();
        Database db;

        private static readonly HttpClient client = new HttpClient();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //using bundles create a system with the back button that either takes you to the intro page or profile page
            //so if come from intro make int = 1 and then use if clause to deal with it

            try
            {


                SetContentView(Resource.Layout.edit_profile_layout);
            }

            catch (Exception e)
            {
                System.Exception myException = e;
                Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                error.Show();

            }

            ActionBar.Hide();
            try
            {

                //Create Database
                db = new Database();
                db.createDatabaseInfo();

                //Load Data  
                LoadData();

                CheckBox male = FindViewById<CheckBox>(Resource.Id.male);
                CheckBox female = FindViewById<CheckBox>(Resource.Id.female);
                CheckBox none = FindViewById<CheckBox>(Resource.Id.none);
                var done = FindViewById<Button>(Resource.Id.done);
                var namer = FindViewById<EditText>(Resource.Id.namer);
                var weighter = FindViewById<EditText>(Resource.Id.weighter);
                var back = FindViewById<ImageButton>(Resource.Id.back);
                var toolbartitle = FindViewById<TextView>(Resource.Id.toolbar_title);
                var or = FindViewById<TextView>(Resource.Id.or);
                var login = FindViewById<Button>(Resource.Id.login);
                var passworder = FindViewById<EditText>(Resource.Id.passworder);

                login.Visibility = ViewStates.Invisible;
                or.Visibility = ViewStates.Invisible;

                string a = "doesn't work";

                male.Click += (o, e) =>
                {
                    if (female.Checked)
                    { female.Checked = false; };
                    if (none.Checked)
                    { none.Checked = false; };
                    a = "male";
                };

                female.Click += (o, e) =>
                {
                    if (male.Checked)
                    { male.Checked = false; };
                    if (none.Checked)
                    { none.Checked = false; };
                    a = "female";
                };

                none.Click += (o, e) =>
                {
                    if (male.Checked)
                    { male.Checked = false; };
                    if (female.Checked)
                    { female.Checked = false; };
                    a = "";
                };
                var comefrom = this.Intent.Extras.GetString("comefrom");

                /*if (this.Intent.Extras != null)
                {


                    if (comefrom == "intro")
                    {
                        back.Click += delegate
                        {
                            var intent = new Intent(this, typeof(IntroActivity));

                            var bundle1 = new Bundle();
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };

                        login.Visibility = ViewStates.Visible;
                        or.Visibility = ViewStates.Visible;

                        login.Click += delegate
                        {
                            var intent = new Intent(this, typeof(Login));

                            var bundle1 = new Bundle();
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };
                    }

                    if (comefrom == "login")
                    {
                        back.Click += delegate
                        {
                            var intent = new Intent(this, typeof(Login));

                            var bundle1 = new Bundle();
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };

                        login.Visibility = ViewStates.Visible;
                        or.Visibility = ViewStates.Visible;

                        login.Click += delegate
                        {
                            var intent = new Intent(this, typeof(Login));

                            var bundle1 = new Bundle();
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };
                    }

                    if (comefrom == "profile")
                    {
                        back.Click += delegate
                        {
                            var intent = new Intent(this, typeof(Profile));

                            var bundle1 = new Bundle();
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };

                        passworder.Visibility = ViewStates.Invisible;
                        toolbartitle.Text = "Edit Profile";
                        done.Text = "                         Save Changes                         ";
                    }
                };*/

                //if (comefrom != "profile")

                // {
                done.Click += async delegate
                {
                    try
                    {
                    /*
                    if (male.Checked == true)
                    { a = "male"; }
                    if (female.Checked == true)
                    { a = "female"; }
                    if (none.Checked == true)
                    { a = "none"; }
                    */
                        string name = namer.Text;
                        name = name.Trim();
                    /*
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    //string postData = "username" + user + "&password" + password;
                    string info = "{\"name\"" + ":" + '"' + name + '"' +","+ "\"weight\"" + ":" + '"' + weighter.Text + '"'+"," + "\"sex\"" + ":" + '"' + a + '"' + "}";
                    byte[] data = Encoding.ASCII.GetBytes(info);

                    WebRequest request = WebRequest.Create("http://51.140.38.46:8080/make_profile");
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

                    if (responseContent != "This username has already been taken")
                    {*/


                        try
                        {
                            try
                            {
                                var test = listSource[0].Name;

                                Toast error = Toast.MakeText(this, "Account Already Created, Please Log In", ToastLength.Short);
                                error.Show();
                            }
                            catch
                            {

                                Info info = new Info()
                                {
                                    Id = 0,
                                    Name = name,
                                    Sex = a,
                                    Weight = weighter.Text,
                                    Username = name,
                                    Password = passworder.Text,
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
                                    Workout = "",
                                    Days = 0
                                };

                                db.insertIntoTableInfo(info);
                                LoadData();

                                string database = listSource[0].Name;

                                Toast saved = Toast.MakeText(this, database, ToastLength.Short);
                                saved.Show();

                                var intent = new Intent(this, typeof(WorkoutSelecter));

                                var bundle1 = new Bundle();
                                bundle1.PutString("comefrom", "signup");
                                // intent.PutExtras(bundle1);

                                this.StartActivity(intent);
                            }

                            
                            }

                        catch (Exception e)
                        {
                            System.Exception myException = e;
                            Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                            error.Show();

                        }





                    //};

                }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                        error.Show();

                    }

                };
            }
            /*}

           else
            {
                done.Click += async delegate
                {
                    try
                    {

                        if (male.Checked == true)
                        {
                            a = "male";
                        }
                        if (female.Checked == true)
                        {
                            a = "female";
                        }
                        if (none.Checked == true)
                        {
                            a = "none";
                        }

                        string name = namer.Text;
                        name = name.Trim();

                        ASCIIEncoding encoding = new ASCIIEncoding();
                        //string postData = "username" + user + "&password" + password;
                        string info = "name = " + name + ". weight = " + weighter.Text + ". sex = " + a + ".";
                        byte[] data = Encoding.ASCII.GetBytes(info);

                        WebRequest request = WebRequest.Create("http://104.245.38.52:8080/edit_profile");
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

                        if (responseContent == "Account updated")
                        {
                            var intent = new Intent(this, typeof(Profile));

                            var bundle1 = new Bundle();
                            bundle1.PutString("namerText", name);
                            intent.PutExtras(bundle1);

                            this.StartActivity(intent);
                        };

                    }
                    catch (Exception e)
                    {
                        System.Exception myException = e;
                        Toast error = Toast.MakeText(this, e.Message, ToastLength.Short);
                        error.Show();

                    }
                };

            }*/
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