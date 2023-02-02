using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Activity;
using Android.Views;

/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 02/02/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

namespace WinDateFrom.Xamarin
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity, View.IOnClickListener
    {
        EditText date, name;
        TextView result, anniversary;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            date = FindViewById<EditText>(Resource.Id.editText2);
            name = FindViewById<EditText>(Resource.Id.editText1);
            result = FindViewById<TextView>(Resource.Id.textView1);
            anniversary = FindViewById<TextView>(Resource.Id.textView2);
            Button b = FindViewById<Button>(Resource.Id.button1);
            b.SetOnClickListener(this);
            SetAmbientEnabled();
        }

        public void OnClick(View v)
        {
            Java.Util.Date d = new Java.Util.Date();
            Java.Util.Date d1;
            anniversary.Text = "";
            result.Text = "";
            try
            {
                d1 = new Java.Util.Date(date.Text);
            } catch (Java.Lang.IllegalArgumentException ex)
            {
                result.Text = Resources.GetString(Resource.String.invalid_rvalue);
                return;
            }
            long diff = d.Time - d1.Time;
            diff = diff / (1000 * 3600 * 24);
            result.Text = Resources.GetString(Resource.String.you_meet) + " "+ name.Text+" "+ Resources.GetString(Resource.String.about)+" "+diff.ToString()+" "+ Resources.GetString(Resource.String.days_ago)+".";
            if (d.GetDate() == d1.GetDate())
                if (d.Month == d1.Month)
                    anniversary.Text = Resources.GetString(Resource.String.is_your_anniversary);
                else
                    anniversary.Text = Resources.GetString(Resource.String.is_your_mesiversary);
        }
    }
}


