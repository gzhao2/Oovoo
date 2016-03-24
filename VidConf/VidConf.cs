using System;

using Xamarin.Forms;

namespace VidConf
{
	public class App : Application
	{
		static volatile App _Instance;
		static object _SyncRoot = new Object();


		public static App Instance {
			get {
				if (_Instance == null)
					lock (_SyncRoot)
						if (_Instance == null)
							_Instance = new App ();

				return _Instance;
			}
		}

		public App ()
		{
			// The root page of your application
			MainPage = new LoginPage();
		}

		public Action FinishLogin {
			get {
				return new Action (async () => {
					MainPage = new ConverencePage();
				});
			}
		}


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

