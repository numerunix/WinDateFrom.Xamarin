using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Activity;
using Android.Views;
using System.ComponentModel;

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
    public class MainActivity : WearableActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            Button b = FindViewById<Button>(Resource.Id.button1);
            b.SetOnClickListener(new MyClickListener(FindViewById<EditText>(Resource.Id.editText2), FindViewById<EditText>(Resource.Id.editText1), FindViewById<TextView>(Resource.Id.textView1), FindViewById<TextView>(Resource.Id.textView2), Resources));
            SetAmbientEnabled();
        }

    }
}


