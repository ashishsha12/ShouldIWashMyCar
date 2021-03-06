﻿
using Android.App;
using Android.OS;
using Core;

using Xamarin.Forms.Platform.Android;
using Android.Content.PM;


namespace ShouldIWashMyCar.Android
{
	[Activity (Label = "Car Wash", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Xamarin.FormsMaps.Init (this, bundle);
			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (App.GetMainPage ());
		}
	}
}

