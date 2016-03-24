using System;
using Xamarin.Forms;
using VidConf;
using Xamarin.Forms.Platform.iOS;
using VidConf.iOS;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using System.Net;
using Foundation;
using Acr.UserDialogs;
using Oovoo;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]
namespace VidConf.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		string token = @"MDAxMDAxAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUwgVRdHdKQIMqCCMMEH0nXttKVzyszUUQ2g6IhVF7EvudcEaahwT4AyYnMguX9asDHxzWzm8zgL%2BsA2PKqPODmm2NENSn1KGRD2R4X1AxFwU6f10NGV4j34Lg6miVddk%3D";

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			AppDelegate.sdk = ooVooClient.SharedInstance;

			AppDelegate.sdk.AuthorizeClient (token, completion: (r) => {
				sdk_error a = ((SdkResult)r).Result;
				if (a == sdk_error.Ok){
					UserDialogs.Instance.Toast (new ToastConfig (ToastEvent.Success, "Autorized"));
//					AppDelegate.sdk.Account.DidAccountLogIn+= (sender, e) => {
//						UserDialogs.Instance.Toast (new ToastConfig (ToastEvent.Success, "Logged in"));
//
//					};
//
//					AppDelegate.sdk.Account.DidAccountLogOut+= (sender, e) => {
//						UserDialogs.Instance.Toast (new ToastConfig (ToastEvent.Success, "Logged Out"));
//
//					};
					AppDelegate.sdk.Account.Delegate = new DelegateAccount();
					AppDelegate.Username = "rizkyarionug";
					AppDelegate.sdk.Account.Login (AppDelegate.Username, completion: (s) => {
						sdk_error b = ((SdkResult)s).Result;
						if (b == sdk_error.Ok){
							UserDialogs.Instance.Toast (new ToastConfig (ToastEvent.Success, "Logged in"));
							App.Instance.FinishLogin.Invoke ();
//							AppDelegate.sdk.Account.Logout();
						}
					});
				}
			});
		

		}

	}

	public class DelegateAccount: ooVooAccountDelegate{
		public override void DidAccountLogIn (ooVooAccount account)
		{
//			base.DidAccountLogIn (account);
		}

		public override void DidAccountLogOut (ooVooAccount account)
		{
//			base.DidAccountLogOut (account);
		}
	}
}

