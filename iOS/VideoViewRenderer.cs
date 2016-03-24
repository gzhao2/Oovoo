using System;
using Xamarin.Forms.Platform.iOS;
using System.Drawing;
using Xamarin.Forms;
using UIKit;
using AVFoundation;
using Foundation;
using CoreGraphics;
using CoreMedia;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using ObjCRuntime;
using MediaPlayer;
using ImageIO;
using CoreAnimation;
using System.Diagnostics;
using Acr.UserDialogs;
using Oovoo;
using VidConf;
using VidConf.iOS;

[assembly: ExportRenderer (typeof (VideoCustomView), typeof (VideoViewRenderer))]
namespace VidConf.iOS
{
	public class VideoViewRenderer : ViewRenderer<VideoCustomView, UIView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<VideoCustomView> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
				return;

			UIView container = new UIView(new CGRect(0, 0, 310, 310));
			ooVooVideoPanel UserVideoPanel = new ooVooVideoPanel() { Frame = new CGRect(0, 0, 310, 310) };
			container.AddSubview(UserVideoPanel);
			AppDelegate.sdk.AVChat.Delegate = new DelegateAV();
			AppDelegate.sdk.AVChat.VideoController.Delegate = new DelegateAVController();
			AppDelegate.sdk.AVChat.VideoController.BindVideoRender(AppDelegate.Username, Runtime.GetINativeObject<IooVooVideoRender>(UserVideoPanel.Handle, false));
			AppDelegate.sdk.AVChat.VideoController.OpenCamera();

			SetNativeControl(container);

			AppDelegate.sdk.AVChat.AudioController.InitAudio ((_sdkResult) => {
				AppDelegate.sdk.AVChat.VideoController.StartTransmitVideo();
				AppDelegate.sdk.AVChat.Join("indonesia", AppDelegate.Username);
			});

		}
	}


	public class DelegateAVController: ooVooVideoControllerDelegate{
		public override void DidCameraStateChange (bool state, string devId, int width, int height, int fps, sdk_error code)
		{
//			throw new NotImplementedException ();
		}

		public override void DidRemoteVideoStateChange (string uid, ooVooAVChatRemoteVideoState state, int width, int height, sdk_error code)
		{
//			throw new NotImplementedException ();
		} 
		public override void DidVideoPreviewStateChange (bool state, string devId, sdk_error code)
		{
//			throw new NotImplementedException ();
		}
		public override void DidVideoTransmitStateChange (bool state, string devId, sdk_error code)
		{
//			throw new NotImplementedException ();
		}
	}

	public class DelegateAV: ooVooAVChatDelegate
	{
		public override void DidParticipantJoin(ooVooParticipant participant, string user_data)
		{
			UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Participant Joined: " + participant.ParticipantID));

			//			AppDelegate.sdk.AVChat.VideoController.RegisterRemoteVideo ("rizkyario");
			//			base.DidParticipantJoin (participant, user_data);
		}

		public override void DidConferenceStateChange(ooVooAVChatState state, sdk_error code)
		{
			if (state == ooVooAVChatState.Joined)
			{
				UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Joined"));

				//				AppDelegate.Client.AVChat.VideoController.BindVideoRender (username, Runtime.GetINativeObject<IooVooVideoRender> (AppDelegate.UserVideoPanel.Handle, false));
				//				AppDelegate.Client.AVChat.VideoController.OpenCamera ();
			}
			//			base.DidConferenceStateChange (state, code);
		}

		public override void DidConferenceError(sdk_error code)
		{
			UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Conference Error: " + code));

			//			base.DidConferenceError (code);
		}

		public override void DidNetworkReliabilityChange(NSNumber score)
		{
			UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Network Reliability: " + score));
			//			base.DidNetworkReliabilityChange (score);
		}

		public override void DidParticipantLeave(ooVooParticipant participant)
		{
			UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Participant Leave: " + participant.ParticipantID));
			//			base.DidParticipantLeave (participant);
		}

		public override void DidReceiveData(string uid, NSData data)
		{
			//			base.DidReceiveData (uid, data);
		}

		public override void DidSecurityState(bool is_secure)
		{
			//UserDialogs.Instance.Toast(new ToastConfig(ToastEvent.Success, "Security State: " + is_secure.ToString()));
			//			base.DidSecurityState (is_secure);
		}
	}
		
}
