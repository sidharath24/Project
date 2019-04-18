using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView ShowAgeTv, AddressTv, PhoneTv, WelcomeTv;
        SeekBar AgeSb;
        RadioButton GraduatedRdb, ContinuedRdb;
        Button NextBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            WelcomeTv = (TextView)FindViewById(Resource.Id.TvWelcome);
            ShowAgeTv = (TextView)FindViewById(Resource.Id.TvAgeShow);
            AddressTv = (TextView)FindViewById(Resource.Id.TvAddress);
            PhoneTv = (TextView)FindViewById(Resource.Id.TvPhone);
            AgeSb = (SeekBar)FindViewById(Resource.Id.SbAge);
            GraduatedRdb = (RadioButton)FindViewById(Resource.Id.RdbGraduate);
            ContinuedRdb = (RadioButton)FindViewById(Resource.Id.RdbContinued);

            WelcomeTv.Text = "Hey " + MainActivity.TvUsername.Text;

            AgeSb.ProgressChanged += delegate
            {
                ShowAgeTv.Text = AgeSb.Progress.ToString();
            };
            NextBtn.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Page3));
                StartActivity(intent);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

