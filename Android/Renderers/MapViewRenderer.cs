﻿using System;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Xamarin.Forms;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;

[assembly: ExportRenderer (typeof(Core.CustomMap), typeof(ShouldIWashMyCar.Android.MapViewRenderer))]
namespace ShouldIWashMyCar.Android
{
	public class MapViewRenderer : MapRenderer
	{
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var androidMapView = (MapView)Control;
			var formsMap = (Map)sender;

			if (e.PropertyName.Equals ("VisibleRegion")) {
				androidMapView.Map.Clear ();

				var formsPins = formsMap.Pins;

				foreach (var formsPin in formsPins) {
					var markerWithIcon = new MarkerOptions ();

					markerWithIcon.SetPosition (new LatLng (formsPin.Position.Latitude, formsPin.Position.Longitude));
					markerWithIcon.SetTitle (formsPin.Label);
					markerWithIcon.SetSnippet (formsPin.Address);

					if (formsPin.Type == PinType.Generic)
						markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.CurrentLocation));
					else
						markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.CarWashMapIcon));
						
					androidMapView.Map.AddMarker (markerWithIcon);
				}
			}

			base.OnElementPropertyChanged (sender, e);
		}
	}
}