using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Oovoo
{
	// @interface SdkResult : NSObject
	[BaseType (typeof(NSObject))]
	interface SdkResult
	{
		// @property (readonly, getter = Result, atomic) sdk_error Result;
		[Export ("Result")]
		sdk_error Result { [Bind ("Result")] get; }

		// @property (readonly, atomic) NSDictionary * userInfo;
		[Export ("userInfo")]
		NSDictionary UserInfo { get; }
	}

	// @interface ooVooSdkApiNotInited : SdkResult
	[BaseType (typeof(SdkResult))]
	interface ooVooSdkApiNotInited
	{
	}

	// @interface ooVooSdkNotLoggedIn : SdkResult
	[BaseType (typeof(SdkResult))]
	interface ooVooSdkNotLoggedIn
	{
	}

	// typedef void (^CompletionHandler)(SdkResult *);
	delegate void CompletionHandler (SdkResult arg0);


	// @protocol ooVooAVChatDelegate <NSObject>
	[BaseType (typeof(NSObject))]
	[Model]
	interface ooVooAVChatDelegate
	{
		// @required -(void)didParticipantJoin:(id<ooVooParticipant>)participant user_data:(NSString *)user_data;
		//		[Abstract]
		[Export ("didParticipantJoin:user_data:"), EventArgs ("ooVooAVChatParticipantJoin")]
		void DidParticipantJoin (ooVooParticipant participant, string user_data);

		// @required -(void)didParticipantLeave:(id<ooVooParticipant>)participant;
		//		[Abstract]
		[Export ("didParticipantLeave:"), EventArgs ("ooVooAVChatParticipantLeaved")]
		void DidParticipantLeave (ooVooParticipant participant);

		// @required -(void)didConferenceStateChange:(ooVooAVChatState)state error:(sdk_error)code;
		//		[Abstract]
		[Export ("didConferenceStateChange:error:"), EventArgs ("ooVooAVChatConferenceStateChanged")]
		void DidConferenceStateChange (ooVooAVChatState state, sdk_error code);

		// @required -(void)didReceiveData:(NSString *)uid data:(NSData *)data;
		//		[Abstract]
		[Export ("didReceiveData:data:"), EventArgs ("ooVooAVChatDataReceived")]
		void DidReceiveData (string uid, NSData data);

		// @required -(void)didConferenceError:(sdk_error)code;
		//		[Abstract]
		[Export ("didConferenceError:"), EventArgs ("ooVooAVChatConferenceDidError")]
		void DidConferenceError (sdk_error code);

		// @required -(void)didNetworkReliabilityChange:(NSNumber *)score;
		//		[Abstract]
		[Export ("didNetworkReliabilityChange:"), EventArgs ("ooVooAVChatNetworkReliabilityChanged")]
		void DidNetworkReliabilityChange (NSNumber score);

		// @required -(void)didSecurityState:(_Bool)is_secure;
		//		[Abstract]
		[Export ("didSecurityState:"), EventArgs ("ooVooAVChatSecurityStated")]
		void DidSecurityState (bool is_secure);
	}

	// @protocol ooVooAVChat <NSObject>
	[Protocol]
	[BaseType (typeof (NSObject),
		Delegates=new string [] {"WeakDelegate"},
		Events=new Type [] { typeof (ooVooAVChatDelegate) })]
	interface ooVooAVChat
	{
		[Wrap ("WeakDelegate")]
		ooVooAVChatDelegate Delegate { get; set; }

		// @required @property (retain, atomic) id<ooVooAVChatDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @required @property (readonly, getter = isInCallMessagePermit, assign) BOOL isInCallMessagePermit;
		[Export ("isInCallMessagePermit")]
		bool IsInCallMessagePermit { [Bind ("isInCallMessagePermit")] get; }

		// @required @property (readonly, getter = get_audiocontroller, retain) id<ooVooAudioController> AudioController;
		[Export ("AudioController", ArgumentSemantic.Retain)]
		ooVooAudioController AudioController { [Bind ("get_audiocontroller")] get; }

		// @required @property (readonly, getter = get_videocontroller, retain) id<ooVooVideoController> VideoController;
		[Export ("VideoController", ArgumentSemantic.Retain)]
		ooVooVideoController VideoController { [Bind ("get_videocontroller")] get; }

		// @required -(void)join:(NSString *)cid user_data:(NSString *)data;
		//		[Abstract]
		[Export ("join:user_data:")]
		void Join (string cid, string data);

		// @required -(void)leave;
		//		[Abstract]
		[Export ("leave")]
		void Leave ();

		// @required -(void)sendData:(NSString *)uid data:(NSData *)buffer completion:(CompletionHandler)completion;
		//		[Abstract]
		[Export ("sendData:data:completion:")]
		void SendData (string uid, NSData buffer, CompletionHandler completion);

		// @required -(void)sendData:(NSData *)buffer completion:(CompletionHandler)completion;
		//		[Abstract]
		[Export ("sendData:completion:")]
		void SendData (NSData buffer, CompletionHandler completion);

		// @required -(void)registerPlugin:(id<ooVooPluginFactory>)plugin completion:(CompletionHandler)completion;
		//		[Abstract]
		[Export ("registerPlugin:completion:")]
		void RegisterPlugin (ooVooPluginFactory plugin, CompletionHandler completion);

		// @required -(void)unregisterPlugin:(id<ooVooPluginFactory>)plugin;
		//		[Abstract]
		[Export ("unregisterPlugin:")]
		void UnregisterPlugin (ooVooPluginFactory plugin);

		// @required -(NSString *)getUserFullName;
		//		[Abstract]
		[Export ("getUserFullName")]
		////[Verify (MethodToProperty)]
		string UserFullName { get; }

		// @required -(BOOL)isResolutionSuported:(ResolutionLevel)resolution;
		//		[Abstract]
		[Export ("isResolutionSuported:")]
		bool IsResolutionSuported (ResolutionLevel resolution);
	}

	// @protocol ooVooPluginFactory <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooPluginFactory
	{
		// @required -(void *)getooVooPluginFactoryNative;
		[Abstract]
		[Export ("getooVooPluginFactoryNative")]
		////[Verify (MethodToProperty)]
		unsafe void GetooVooPluginFactoryNative ();
	}

	// @protocol ooVooAccountDelegate <NSObject>
//	[Protocol, Model]
	[Model]
	[BaseType (typeof(NSObject))]
	interface ooVooAccountDelegate
	{
		// @required -(void)didAccountLogIn:(id<ooVooAccount>)account;
//		[Abstract]
		[Export ("didAccountLogIn:"), EventArgs ("ooVooAccountDidLogin")]
		void DidAccountLogIn (ooVooAccount account);

		// @required -(void)didAccountLogOut:(id<ooVooAccount>)account;
//		[Abstract]
		[Export ("didAccountLogOut:"), EventArgs ("ooVooAccountDidLogout")]
		void DidAccountLogOut (ooVooAccount account);
	}

	// @protocol ooVooAccount <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
	[Protocol]
	[BaseType (typeof (NSObject),
		Delegates=new string [] {"WeakDelegate"},
		Events=new Type [] { typeof (ooVooAccountDelegate) })]
	interface ooVooAccount
	{
		[Wrap ("WeakDelegate")]
		ooVooAccountDelegate Delegate { get; set; }

		// @required @property (retain, atomic) id<ooVooAccountDelegate> delegate;
//		[Abstract]
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @required @property (getter = get_uid, atomic) NSString * uid;
//		[Abstract]
		[Export ("uid")]
		string Uid { [Bind ("get_uid")] get; set; }

		// @required @property (readonly, getter = state, atomic) AccountState state;
//		[Abstract]
		[Export ("state")]
		AccountState State { [Bind ("state")] get; }

		// @required -(void)login:(NSString *)uid completion:(CompletionHandler)completion;
//		[Abstract]
		[Export ("login:completion:")]
		void Login (string uid, CompletionHandler completion);

		// @required -(void)logout;
//		[Abstract]
		[Export ("logout")]
		void Logout ();
	}

	// [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const OOVOOAudioRouteDidChangeNotification;
		[Field ("OOVOOAudioRouteDidChangeNotification")]
		NSString OOVOOAudioRouteDidChangeNotification { get; }

		// extern NSString *const OOVOOAudioRouteNameKey;
		[Field ("OOVOOAudioRouteNameKey")]
		NSString OOVOOAudioRouteNameKey { get; }

		// extern NSString *const OOVOOAudioRouteTypeKey;
		[Field ("OOVOOAudioRouteTypeKey")]
		NSString OOVOOAudioRouteTypeKey { get; }
	}

	// @protocol ooVooParticipant <NSObject>
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ooVooParticipant
	{
		// @required @property (readonly, getter = participantID) NSString * participantID;
		//[Abstract]
		[Export ("participantID")]
		string ParticipantID { [Bind ("participantID")] get; }

		// @required @property (readonly, getter = participantType) ooVooAVParticipantType type;
		//[Abstract]
		[Export ("type")]
		ooVooAVParticipantType Type { [Bind ("participantType")] get; }
	}

	// @protocol ooVooDevice <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooDevice
	{
		// @required @property (readonly, getter = deviceName) NSString * deviceName;
		[Abstract]
		[Export ("deviceName")]
		string DeviceName { [Bind ("deviceName")] get; }

		// @required @property (readonly, getter = deviceID) NSString * deviceID;
		[Abstract]
		[Export ("deviceID")]
		string DeviceID { [Bind ("deviceID")] get; }
	}

	// @protocol ooVooVideoDevice <NSObject, ooVooDevice>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooVideoDevice : ooVooDevice
	{
		// @required -(BOOL)isResolutionSuported:(ResolutionLevel)resolution;
		[Abstract]
		[Export ("isResolutionSuported:")]
		bool IsResolutionSuported (ResolutionLevel resolution);

		// @required -(BOOL)isFront;
		[Abstract]
		[Export ("isFront")]
		//[Verify (MethodToProperty)]
		bool IsFront { get; }

		// @required -(NSArray *)getAvailableResolutions;
		[Abstract]
		[Export ("getAvailableResolutions")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AvailableResolutions { get; }
	}

	// @protocol ooVooEffect <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooEffect
	{
		// @required @property (readonly, getter = effectName) NSString * effectName;
		[Abstract]
		[Export ("effectName")]
		string EffectName { [Bind ("effectName")] get; }

		// @required @property (readonly, getter = effectID) NSString * effectID;
		[Abstract]
		[Export ("effectID")]
		string EffectID { [Bind ("effectID")] get; }

		// @required @property (readonly, getter = iconUrl) NSString * iconUrl;
		[Abstract]
		[Export ("iconUrl")]
		string IconUrl { [Bind ("iconUrl")] get; }
	}

	// @protocol ooVooAudioControllerDelegate
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooAudioControllerDelegate
	{
		// @required -(void)didAudioTransmitStateChange:(BOOL)state error:(sdk_error)code;
		[Abstract]
		[Export ("didAudioTransmitStateChange:error:")]
		void DidAudioTransmitStateChange (bool state, sdk_error code);

		// @required -(void)didAudioReceiveStateChange:(BOOL)state error:(sdk_error)code;
		[Abstract]
		[Export ("didAudioReceiveStateChange:error:")]
		void DidAudioReceiveStateChange (bool state, sdk_error code);
	}

	// @protocol ooVooAudioController <NSObject>
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ooVooAudioController
	{
		[Wrap ("WeakDelegate")]
		ooVooAudioControllerDelegate Delegate { get; set; }

		// @required @property (retain, atomic) id<ooVooAudioControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)initAudio:(CompletionHandler)complition;
		[Export ("initAudio:")]
		void InitAudio (CompletionHandler complition);

		// @required -(BOOL)isPlaybackMuted;
		[Export ("isPlaybackMuted")]
		//[Verify (MethodToProperty)]
		bool IsPlaybackMuted { get; }

		// @required -(void)setPlaybackMute:(BOOL)flag;
		[Export ("setPlaybackMute:")]
		void SetPlaybackMute (bool flag);

		// @required -(BOOL)isRecordMuted;
		[Export ("isRecordMuted")]
		//[Verify (MethodToProperty)]
		bool IsRecordMuted { get; }

		// @required -(void)setRecordMuted:(BOOL)recordEnable;
		[Export ("setRecordMuted:")]
		void SetRecordMuted (bool recordEnable);

		// @required -(void)setConfig:(NSString *)val forKey:(ooVooAudioControllerConfigKey)key;
		[Export ("setConfig:forKey:")]
		void SetConfig (string val, ooVooAudioControllerConfigKey key);

		// @required -(NSString *)getConfig:(ooVooAudioControllerConfigKey)key;
		[Export ("getConfig:")]
		string GetConfig (ooVooAudioControllerConfigKey key);
	}

	interface IooVooVideoRender {}

	// @protocol ooVooVideoRender <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooVideoRender
	{
		// @required -(UIViewController *)viewController;
		[Abstract]
		[Export ("viewController")]
		//[Verify (MethodToProperty)]
		UIViewController ViewController { get; }
	}

	// @protocol ooVooVideoControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooVideoControllerDelegate
	{
		// @required -(void)didRemoteVideoStateChange:(NSString *)uid state:(ooVooAVChatRemoteVideoState)state width:(const int)width height:(const int)height error:(sdk_error)code;
		[Abstract]
		[Export ("didRemoteVideoStateChange:state:width:height:error:")]
		void DidRemoteVideoStateChange (string uid, ooVooAVChatRemoteVideoState state, int width, int height, sdk_error code);

		// @required -(void)didCameraStateChange:(BOOL)state devId:(NSString *)devId width:(const int)width height:(const int)height fps:(const int)fps error:(sdk_error)code;
		[Abstract]
		[Export ("didCameraStateChange:devId:width:height:fps:error:")]
		void DidCameraStateChange (bool state, string devId, int width, int height, int fps, sdk_error code);

		// @required -(void)didVideoTransmitStateChange:(BOOL)state devId:(NSString *)devId error:(sdk_error)code;
		[Abstract]
		[Export ("didVideoTransmitStateChange:devId:error:")]
		void DidVideoTransmitStateChange (bool state, string devId, sdk_error code);

		// @required -(void)didVideoPreviewStateChange:(BOOL)state devId:(NSString *)devId error:(sdk_error)code;
		[Abstract]
		[Export ("didVideoPreviewStateChange:devId:error:")]
		void DidVideoPreviewStateChange (bool state, string devId, sdk_error code);
	}

	// @protocol ooVooVideoController <NSObject>
//	[Model]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ooVooVideoController
	{
		[Wrap ("WeakDelegate")]
		ooVooVideoControllerDelegate Delegate { get; set; }

		// @required @property (retain, atomic) id<ooVooVideoControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
		NSObject WeakDelegate { get; set; }

		// @required @property (getter = getActiveDevice, setter = setActiveDevice:, atomic) id<ooVooVideoDevice> activeDevice;
		[Export ("activeDevice", ArgumentSemantic.Assign)]
		ooVooVideoDevice ActiveDevice { [Bind ("getActiveDevice")] get; [Bind ("setActiveDevice:")] set; }

		// @required -(void)setConfig:(NSString *)val forKey:(ooVooVideoControllerConfigKey)key;
//		[Abstract]
		[Export ("setConfig:forKey:")]
		void SetConfig (string val, ooVooVideoControllerConfigKey key);

		// @required -(NSString *)getConfig:(ooVooVideoControllerConfigKey)key;
//		[Abstract]
		[Export ("getConfig:")]
		string GetConfig (ooVooVideoControllerConfigKey key);

		// @required -(void)openPreview;
//		[Abstract]
		[Export ("openPreview")]
		void OpenPreview ();

		// @required -(void)closePreview;
//		[Abstract]
		[Export ("closePreview")]
		void ClosePreview ();

		// @required -(void)openCamera;
//		[Abstract]
		[Export ("openCamera")]
		void OpenCamera ();

		// @required -(void)closeCamera;
//		[Abstract]
		[Export ("closeCamera")]
		void CloseCamera ();

		// @required -(void)startTransmitVideo;
//		[Abstract]
		[Export ("startTransmitVideo")]
		void StartTransmitVideo ();

		// @required -(void)stopTransmitVideo;
//		[Abstract]
		[Export ("stopTransmitVideo")]
		void StopTransmitVideo ();

		// @required -(BOOL)isVideoTransmited;
//		[Abstract]
		[Export ("isVideoTransmited")]
		//[Verify (MethodToProperty)]
		bool IsVideoTransmited { get; }

		// @required -(void)bindVideoRender:(NSString *)uid render:(id<ooVooVideoRender>)render;
//		[Abstract]
		[Export ("bindVideoRender:render:")]
		void BindVideoRender (string uid, IooVooVideoRender render);

		// @required -(void)unbindVideoRender:(NSString *)uid render:(id<ooVooVideoRender>)render;
//		[Abstract]
		[Export ("unbindVideoRender:render:")]
		void UnbindVideoRender (string uid, IooVooVideoRender render);

		// @required -(void)registerRemoteVideo:(NSString *)uid;
//		[Abstract]
		[Export ("registerRemoteVideo:")]
		void RegisterRemoteVideo (string uid);

		// @required -(void)unRegisterRemoteVideo:(NSString *)uid;
//		[Abstract]
		[Export ("unRegisterRemoteVideo:")]
		void UnRegisterRemoteVideo (string uid);

		// @required -(NSArray *)getDevicesList;
//		[Abstract]
		[Export ("getDevicesList")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] DevicesList { get; }

		// @required -(NSArray *)getEffectsList;
//		[Abstract]
		[Export ("getEffectsList")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] EffectsList { get; }

		// @required -(ResolutionLevel)sizeToCameraResolutionLevel:(int)width picHeight:(int)height;
//		[Abstract]
		[Export ("sizeToCameraResolutionLevel:picHeight:")]
		ResolutionLevel SizeToCameraResolutionLevel (int width, int height);
	}

	// @protocol ooVooPluginFactory <NSObject>
	//[Protocol, Model]
	//[BaseType (typeof(NSObject))]
	//interface ooVooPluginFactory
	//{
	// @required -(void *)getooVooPluginFactoryNative;
	//	[Abstract]
	//	[Export ("getooVooPluginFactoryNative")]
	//	//[Verify (MethodToProperty)]
	//	unsafe void* GetooVooPluginFactoryNative();
	//}

	#if poep
	// @protocol ooVooAVChatDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooAVChatDelegate
	{
	// @required -(void)didParticipantJoin:(id<ooVooParticipant>)participant user_data:(NSString *)user_data;
	[Abstract]
	[Export ("didParticipantJoin:user_data:")]
	void DidParticipantJoin (ooVooParticipant participant, string userData);

	// @required -(void)didParticipantLeave:(id<ooVooParticipant>)participant;
	[Abstract]
	[Export ("didParticipantLeave:")]
	void DidParticipantLeave (ooVooParticipant participant);

	// @required -(void)didConferenceStateChange:(ooVooAVChatState)state error:(sdk_error)code;
	[Abstract]
	[Export ("didConferenceStateChange:error:")]
	void DidConferenceStateChange (ooVooAVChatState state, sdk_error code);

	// @required -(void)didReceiveData:(NSString *)uid data:(NSData *)data;
	[Abstract]
	[Export ("didReceiveData:data:")]
	void DidReceiveData (string uid, NSData data);

	// @required -(void)didConferenceError:(sdk_error)code;
	[Abstract]
	[Export ("didConferenceError:")]
	void DidConferenceError (sdk_error code);

	// @required -(void)didNetworkReliabilityChange:(NSNumber *)score;
	[Abstract]
	[Export ("didNetworkReliabilityChange:")]
	void DidNetworkReliabilityChange (NSNumber score);
	}

	// @protocol ooVooAVChat <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooAVChat
	{
	[Wrap ("WeakDelegate")]
	ooVooAVChatDelegate Delegate { get; set; }

	// @required @property (retain, atomic) id<ooVooAVChatDelegate> delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
	NSObject WeakDelegate { get; set; }

	// @required @property (getter = isSslVerifyPeer, setter = setSslVerifyPeer:) BOOL sslVerifyPeer;
	[Export ("sslVerifyPeer")]
	bool SslVerifyPeer { [Bind ("isSslVerifyPeer")] get; [Bind ("setSslVerifyPeer:")] set; }

	// @required @property (readonly, getter = isInCallMessagePermit) BOOL isInCallMessagePermit;
	[Export ("isInCallMessagePermit")]
	bool IsInCallMessagePermit { [Bind ("isInCallMessagePermit")] get; }

	// @required @property (readonly, getter = get_audiocontroller) id<ooVooAudioController> AudioController;
	[Export ("AudioController")]
	ooVooAudioController AudioController { [Bind ("get_audiocontroller")] get; }

	// @required @property (readonly, getter = get_videocontroller) id<ooVooVideoController> VideoController;
	[Export ("VideoController")]
	ooVooVideoController VideoController { [Bind ("get_videocontroller")] get; }

	// @required -(void)join:(NSString *)cid user_data:(NSString *)data;
	[Abstract]
	[Export ("join:user_data:")]
	void Join (string cid, string data);

	// @required -(void)joinDirect:(NSString *)server_ip conference_id:(NSString *)cid;
	[Abstract]
	[Export ("joinDirect:conference_id:")]
	void JoinDirect (string server_ip, string cid);

	// @required -(void)leave;
	[Abstract]
	[Export ("leave")]
	void Leave ();

	// @required -(void)sendData:(NSString *)uid message:(NSData *)message completion:(CompletionHandler)completion;
	[Abstract]
	[Export ("sendData:message:completion:")]
	void SendData (string uid, NSData message, CompletionHandler completion);

	// @required -(void)sendData:(NSData *)message completion:(CompletionHandler)completion;
	[Abstract]
	[Export ("sendData:completion:")]
	void SendData (NSData message, CompletionHandler completion);

	// @required -(void)registerPlugin:(id<ooVooPluginFactory>)plugin;
	//[Abstract]
	//[Export ("registerPlugin:")]
	//void RegisterPlugin (ooVooPluginFactory plugin);

	// @required -(void)unregisterPlugin:(id<ooVooPluginFactory>)plugin;
	//[Abstract]
	//[Export ("unregisterPlugin:")]
	//void UnregisterPlugin (ooVooPluginFactory plugin);

	// @required -(NSString *)getUserFullName;
	[Abstract]
	[Export ("getUserFullName")]
	//[Verify (MethodToProperty)]
	string UserFullName { get; }

	// @required -(BOOL)isResolutionSuported:(ResolutionLevel)resolution;
	[Abstract]
	[Export ("isResolutionSuported:")]
	bool IsResolutionSuported (ResolutionLevel resolution);
	}

	#endif

	// @interface ooVooMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface ooVooMessage
	{
		// @property (readonly, getter = get_from) NSString * from;
		[Export ("from")]
		string From { [Bind ("get_from")] get; }

		// @property (readonly, getter = get_to) NSString * to;
		[Export ("to")]
		string To { [Bind ("get_to")] get; }

		// @property (readonly, getter = get_body) NSString * body;
		[Export ("body")]
		string Body { [Bind ("get_body")] get; }

		// @property (readonly, getter = get_messageId) NSString * messageId;
		[Export ("messageId")]
		string MessageId { [Bind ("get_messageId")] get; }

		// @property (readonly, getter = get_timestamp) uint64_t timestamp;
		[Export ("timestamp")]
		ulong Timestamp { [Bind ("get_timestamp")] get; }

		// -(instancetype)initMessage:(NSString *)to message:(NSString *)message;
		[Export ("initMessage:message:")]
		IntPtr Constructor (string to, string message);

		// -(instancetype)initMessageWithArrayUsers:(NSArray *)to message:(NSString *)message;
		[Export ("initMessageWithArrayUsers:message:")]
		//[Verify (StronglyTypedNSArray)]
		IntPtr Constructor (NSObject[] to, string message);
	}

	// @protocol ooVooMessagingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooMessagingDelegate
	{
		// @required -(void)didMessageReceive:(ooVooMessage *)message;
		[Abstract]
		[Export ("didMessageReceive:")]
		void DidMessageReceive (ooVooMessage message);
	}

	// @protocol ooVooMessaging <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooMessaging
	{
		[Wrap ("WeakDelegate")]
		ooVooMessagingDelegate Delegate { get; set; }

		// @required @property (retain, atomic) id<ooVooMessagingDelegate> delegate;
//		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
		NSObject WeakDelegate { get; set; }

		// @required -(void)send:(ooVooMessage *)message completion:(CompletionHandler)completion;
//		[Abstract]
		[Export ("send:completion:")]
		void Completion (ooVooMessage message, CompletionHandler completion);
	}

	// @protocol ooVooClientLogger <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ooVooClientLogger
	{
		// @required -(void)onLog:(LogLevel)level log:(NSString *)log;
		[Abstract]
		[Export ("onLog:log:")]
		void Log (LogLevel level, string log);
	}

	// @interface ooVooClient : NSObject
	[BaseType (typeof(NSObject))]
	interface ooVooClient
	{
		// @property (getter = isSslVerifyPeer, setter = setSslVerifyPeer:) BOOL sslVerifyPeer;
		[Export ("sslVerifyPeer")]
		bool SslVerifyPeer { [Bind ("isSslVerifyPeer")] get; [Bind ("setSslVerifyPeer:")] set; }

		// @property (readonly, getter = IsAuthorized, atomic) BOOL IsAuthorized;
		[Export ("IsAuthorized")]
		bool IsAuthorized { [Bind ("IsAuthorized")] get; }

		// @property (readonly, getter = app_token, atomic) NSString * ApplicationToken;
		[Export ("ApplicationToken")]
		string ApplicationToken { [Bind ("app_token")] get; }

		// @property (readonly, getter = Account, atomic) id<ooVooAccount> Account;
		[Export ("Account")]
		ooVooAccount Account { [Bind ("Account")] get; }

//		 @property (readonly, getter = AVChat, atomic) id<ooVooAVChat> AVChat;
		[Export ("AVChat")]
		ooVooAVChat AVChat { [Bind ("AVChat")] get; }

		// @property (readonly, getter = Messaging, atomic) id<ooVooMessaging> Messaging;
		[Export ("Messaging")]
		ooVooMessaging Messaging { [Bind ("Messaging")] get; }

		// @property (getter = get_enableMessaging, setter = set_enableMessaging:, atomic) BOOL enableMessaging;
		[Export ("enableMessaging")]
		bool EnableMessaging { [Bind ("get_enableMessaging")] get; [Bind ("set_enableMessaging:")] set; }

		// +(void)setLogger:(id<ooVooClientLogger>)logger;
		[Static]
		[Export ("setLogger:")]
		void SetLogger (ooVooClientLogger logger);

		// +(void)setLogLevel:(LogLevel)level;
		[Static]
		[Export ("setLogLevel:")]
		void SetLogLevel (LogLevel level);

		// +(ooVooClient *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		ooVooClient SharedInstance { get; }

		// -(void)authorizeClient:(NSString *)app_token completion:(CompletionHandler)completion;
		[Export ("authorizeClient:completion:")]
		void AuthorizeClient (string app_token, CompletionHandler completion);

		// -(void)setClientVersion:(NSString *)client_version;
		[Export ("setClientVersion:")]
		void SetClientVersion (string client_version);

		// +(NSString *)getSdkVersion;
		[Static]
		[Export ("getSdkVersion")]
		//[Verify (MethodToProperty)]
		string SdkVersion { get; }

		// -(void)updateConfig:(CompletionHandler)completion;
		[Export ("updateConfig:")]
		void UpdateConfig (CompletionHandler completion);
	}

	// @interface ooVooVideoPanel : UIView <ooVooVideoRender>
	[BaseType (typeof(UIView))]
	interface ooVooVideoPanel : IooVooVideoRender
	{
		// @property (assign, nonatomic) BOOL isVideoRenderStarted;
		[Export ("isVideoRenderStarted")]
		bool IsVideoRenderStarted { get; set; }

		// @property (getter = fitVideoMode, nonatomic, setter = set_fitVideoMode:) BOOL fitVideoMode;
		[Export ("fitVideoMode")]
		bool FitVideoMode { [Bind ("fitVideoMode")] get; [Bind ("set_fitVideoMode:")] set; }

		// -(void)didVideoRenderStart;
		[Export ("didVideoRenderStart")]
		void DidVideoRenderStart ();

		// -(void)didVideoRenderStop;
		[Export ("didVideoRenderStop")]
		void DidVideoRenderStop ();
	}
}