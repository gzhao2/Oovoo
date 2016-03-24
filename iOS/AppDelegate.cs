using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Oovoo;

namespace VidConf.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public static ooVooClient sdk;
		public static string Username;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (App.Instance);

			return base.FinishedLaunching (app, options);

		}


	}
}

