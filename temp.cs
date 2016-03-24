using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Oovoos
{
//	// @interface SdkResult : NSObject
//	[BaseType (typeof(NSObject))]
//	interface SdkResult
//	{
//		// @property (readonly, getter = Result, atomic) sdk_error Result;
//		[Export ("Result")]
//		sdk_error Result { [Bind ("Result")] get; }
//
//		// @property (readonly, atomic) NSDictionary * userInfo;
//		[Export ("userInfo")]
//		NSDictionary UserInfo { get; }
//	}
//
//	// @interface ooVooSdkApiNotInited : SdkResult
//	[BaseType (typeof(SdkResult))]
//	interface ooVooSdkApiNotInited
//	{
//	}
//
//	// @interface ooVooSdkNotLoggedIn : SdkResult
//	[BaseType (typeof(SdkResult))]
//	interface ooVooSdkNotLoggedIn
//	{
//	}
//
//	// typedef void (^CompletionHandler)(SdkResult *);
//	delegate void CompletionHandler (SdkResult arg0);
//
//	// @protocol ooVooPluginFactory <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooPluginFactory
//	{
//		// @required -(void *)getooVooPluginFactoryNative;
//		[Abstract]
//		[Export ("getooVooPluginFactoryNative")]
//		////[Verify (MethodToProperty)]
//		unsafe void GetooVooPluginFactoryNative ();
//	}
//
//	//	[Static]
//	//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const OOVOOAudioRouteDidChangeNotification;
//		[Field ("OOVOOAudioRouteDidChangeNotification", "__Internal")]
//		NSString OOVOOAudioRouteDidChangeNotification { get; }
//
//		// extern NSString *const OOVOOAudioRouteNameKey;
//		[Field ("OOVOOAudioRouteNameKey", "__Internal")]
//		NSString OOVOOAudioRouteNameKey { get; }
//
//		// extern NSString *const OOVOOAudioRouteTypeKey;
//		[Field ("OOVOOAudioRouteTypeKey", "__Internal")]
//		NSString OOVOOAudioRouteTypeKey { get; }
//	}
//
//	// @protocol ooVooParticipant <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooParticipant
//	{
//		// @required @property (readonly, getter = participantID, retain) NSString * participantID;
//		[Abstract]
//		[Export ("participantID", ArgumentSemantic.Retain)]
//		string ParticipantID { [Bind ("participantID")] get; }
//
//		// @required @property (readonly, getter = participantType, assign) ooVooAVParticipantType type;
//		[Abstract]
//		[Export ("type", ArgumentSemantic.Assign)]
//		ooVooAVParticipantType Type { [Bind ("participantType")] get; }
//	}
//
//	// @protocol ooVooDevice <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooDevice
//	{
//		// @required @property (readonly, getter = deviceName, retain) NSString * deviceName;
//		[Abstract]
//		[Export ("deviceName", ArgumentSemantic.Retain)]
//		string DeviceName { [Bind ("deviceName")] get; }
//
//		// @required @property (readonly, getter = deviceID, retain) NSString * deviceID;
//		[Abstract]
//		[Export ("deviceID", ArgumentSemantic.Retain)]
//		string DeviceID { [Bind ("deviceID")] get; }
//	}
//
//	// @protocol ooVooVideoDevice <NSObject, ooVooDevice>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooVideoDevice : ooVooDevice
//	{
//		// @required -(BOOL)isResolutionSuported:(ResolutionLevel)resolution;
//		[Abstract]
//		[Export ("isResolutionSuported:")]
//		bool IsResolutionSuported (ResolutionLevel resolution);
//
//		// @required -(BOOL)isFront;
//		[Abstract]
//		[Export ("isFront")]
//		//////[Verify (MethodToProperty)]
//		bool IsFront { get; }
//
//		// @required -(NSArray *)getAvailableResolutions;
//		[Abstract]
//		[Export ("getAvailableResolutions")]
//		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
//		NSObject[] AvailableResolutions { get; }
//	}
//
//	// @protocol ooVooEffect <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooEffect
//	{
//		// @required @property (readonly, getter = effectName, retain) NSString * effectName;
//		[Abstract]
//		[Export ("effectName", ArgumentSemantic.Retain)]
//		string EffectName { [Bind ("effectName")] get; }
//
//		// @required @property (readonly, getter = effectID, retain) NSString * effectID;
//		[Abstract]
//		[Export ("effectID", ArgumentSemantic.Retain)]
//		string EffectID { [Bind ("effectID")] get; }
//
//		// @required @property (readonly, getter = iconUrl, retain) NSString * iconUrl;
//		[Abstract]
//		[Export ("iconUrl", ArgumentSemantic.Retain)]
//		string IconUrl { [Bind ("iconUrl")] get; }
//
//		// @required @property (readonly, getter = category, retain) NSString * category;
//		[Abstract]
//		[Export ("category", ArgumentSemantic.Retain)]
//		string Category { [Bind ("category")] get; }
//
//		// @required @property (readonly, getter = purchaseID, retain) NSString * purchaseID;
//		[Abstract]
//		[Export ("purchaseID", ArgumentSemantic.Retain)]
//		string PurchaseID { [Bind ("purchaseID")] get; }
//	}
//
//	// @protocol ooVooAudioControllerDelegate
//	[BaseType (typeof(NSObject))]
//	[Model]
//	interface ooVooAudioControllerDelegate
//	{
//		// @required -(void)didAudioTransmitStateChange:(BOOL)state error:(sdk_error)code;
//		[Export ("didAudioTransmitStateChange:error:")]
//		void DidAudioTransmitStateChange (bool state, sdk_error code);
//
//		// @required -(void)didAudioReceiveStateChange:(BOOL)state error:(sdk_error)code;
//		[Export ("didAudioReceiveStateChange:error:")]
//		void DidAudioReceiveStateChange (bool state, sdk_error code);
//	}
//
//	// @protocol ooVooAudioController <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooAudioController
//	{
//		[Wrap ("WeakDelegate")]
//		ooVooAudioControllerDelegate Delegate { get; set; }
//
//		// @required @property (retain, atomic) id<ooVooAudioControllerDelegate> delegate;
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
//		NSObject WeakDelegate { get; set; }
//
//		// @required -(void)initAudio:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("initAudio:")]
//		void InitAudio (CompletionHandler completion);
//
//		// @required -(void)unInitAudio:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("unInitAudio:")]
//		void UnInitAudio (CompletionHandler completion);
//
//		// @required -(BOOL)isPlaybackMuted;
//		//		[Abstract]
//		[Export ("isPlaybackMuted")]
//		//////[Verify (MethodToProperty)]
//		bool IsPlaybackMuted { get; }
//
//		// @required -(void)setPlaybackMute:(BOOL)flag;
//		//		[Abstract]
//		[Export ("setPlaybackMute:")]
//		void SetPlaybackMute (bool flag);
//
//		// @required -(BOOL)isRecordMuted;
//		//		[Abstract]
//		[Export ("isRecordMuted")]
//		//////[Verify (MethodToProperty)]
//		bool IsRecordMuted { get; }
//
//		// @required -(void)setRecordMuted:(BOOL)recordEnable;
//		//		[Abstract]
//		[Export ("setRecordMuted:")]
//		void SetRecordMuted (bool recordEnable);
//
//		// @required -(void)setConfig:(NSString *)val forKey:(ooVooAudioControllerConfigKey)key;
//		//		[Abstract]
//		[Export ("setConfig:forKey:")]
//		void SetConfig (string val, ooVooAudioControllerConfigKey key);
//
//		// @required -(NSString *)getConfig:(ooVooAudioControllerConfigKey)key;
//		//		[Abstract]
//		[Export ("getConfig:")]
//		string GetConfig (ooVooAudioControllerConfigKey key);
//
//		// @required -(void)hold;
//		//		[Abstract]
//		[Export ("hold")]
//		void Hold ();
//
//		// @required -(void)unhold;
//		//		[Abstract]
//		[Export ("unhold")]
//		void Unhold ();
//	}
//
//	// @protocol ooVooVideoData <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooVideoData
//	{
//		// @required @property (readonly, getter = data, retain) NSData * data;
//		[Export ("data", ArgumentSemantic.Retain)]
//		NSData Data { [Bind ("data")] get; }
//
//		// @required @property (readonly, getter = dataLength, assign) int dataLength;
//		[Export ("dataLength")]
//		int DataLength { [Bind ("dataLength")] get; }
//
//		// @required @property (readonly, getter = width, assign) int width;
//		[Export ("width")]
//		int Width { [Bind ("width")] get; }
//
//		// @required @property (readonly, getter = height, assign) int height;
//		[Export ("height")]
//		int Height { [Bind ("height")] get; }
//
//		// @required @property (readonly, getter = colorFormat, assign) ooVooColorFormat colorFormat;
//		[Export ("colorFormat", ArgumentSemantic.Assign)]
//		ooVooColorFormat ColorFormat { [Bind ("colorFormat")] get; }
//
//		// @required @property (readonly, getter = planesCount, assign) int planesCount;
//		[Export ("planesCount")]
//		int PlanesCount { [Bind ("planesCount")] get; }
//
//		// @required -(void *)getPlane:(int)index;
//		[Abstract]
//		[Export ("getPlane:")]
//		unsafe void GetPlane (int index);
//
//		// @required -(int)getPlanePitch:(int)index;
//		[Abstract]
//		[Export ("getPlanePitch:")]
//		int GetPlanePitch (int index);
//	}
//
//	// @protocol ooVooVideoFrame <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooVideoFrame
//	{
//		// @required @property (readonly, retain) id<ooVooVideoData> videoData;
//		[Export ("videoData", ArgumentSemantic.Retain)]
//		ooVooVideoData VideoData { get; }
//
//		// @required @property (readonly, assign) int width;
//		[Export ("width")]
//		int Width { get; }
//
//		// @required @property (readonly, assign) int height;
//		[Export ("height")]
//		int Height { get; }
//
//		// @required @property (readonly, assign) short frameNumber;
//		[Export ("frameNumber")]
//		short FrameNumber { get; }
//
//		// @required @property (readonly, assign) BOOL isKeyFrame;
//		[Export ("isKeyFrame")]
//		bool IsKeyFrame { get; }
//
//		// @required @property (readonly, assign) BOOL isMirror;
//		[Export ("isMirror")]
//		bool IsMirror { get; }
//
//		// @required @property (readonly, assign) int rotationAngle;
//		[Export ("rotationAngle")]
//		int RotationAngle { get; }
//
//		// @required @property (readonly, assign) int deviceRotationAngle;
//		[Export ("deviceRotationAngle")]
//		int DeviceRotationAngle { get; }
//
//		// @required @property (readonly, assign) ooVooColorFormat colorFormat;
//		[Export ("colorFormat", ArgumentSemantic.Assign)]
//		ooVooColorFormat ColorFormat { get; }
//	}
//
//	// @protocol ooVooVideoRender <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooVideoRender
//	{
//		// @optional -(UIViewController *)viewController;
//		[Export ("viewController")]
//		////[Verify (MethodToProperty)]
//		UIViewController ViewController { get; }
//
//		// @optional -(void)onProcessVideoFrame:(id<ooVooVideoFrame>)frame;
//		[Export ("onProcessVideoFrame:")]
//		void OnProcessVideoFrame (ooVooVideoFrame frame);
//	}
//
//	// @protocol ooVooVideoControllerDelegate <NSObject>
//	[BaseType (typeof(NSObject))]
//	[Model]
//	interface ooVooVideoControllerDelegate
//	{
//		// @required -(void)didRemoteVideoStateChange:(NSString *)uid state:(ooVooAVChatRemoteVideoState)state width:(const int)width height:(const int)height error:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didRemoteVideoStateChange:state:width:height:error:")]
//		void DidRemoteVideoStateChange (string uid, ooVooAVChatRemoteVideoState state, int width, int height, sdk_error code);
//
//		// @required -(void)didCameraStateChange:(ooVooDeviceState)state devId:(NSString *)devId width:(const int)width height:(const int)height fps:(const int)fps error:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didCameraStateChange:devId:width:height:fps:error:")]
//		void DidCameraStateChange (ooVooDeviceState state, string devId, int width, int height, int fps, sdk_error code);
//
//		// @required -(void)didVideoTransmitStateChange:(BOOL)state devId:(NSString *)devId error:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didVideoTransmitStateChange:devId:error:")]
//		void DidVideoTransmitStateChange (bool state, string devId, sdk_error code);
//
//		// @required -(void)didVideoPreviewStateChange:(BOOL)state devId:(NSString *)devId error:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didVideoPreviewStateChange:devId:error:")]
//		void DidVideoPreviewStateChange (bool state, string devId, sdk_error code);
//	}
//
//	// @protocol ooVooVideoController <NSObject>
//	[BaseType (typeof (NSObject))]
//	[Model]
//	interface ooVooVideoController
//	{
//		[Wrap ("WeakDelegate")]
//		ooVooVideoControllerDelegate Delegate { get; set; }
//
//		// @required @property (retain, atomic) id<ooVooVideoControllerDelegate> delegate;
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
//		NSObject WeakDelegate { get; set; }
//
//		// @required @property (getter = getActiveDevice, retain, setter = setActiveDevice:, atomic) id<ooVooVideoDevice> activeDevice;
//		[Export ("activeDevice", ArgumentSemantic.Retain)]
//		ooVooVideoDevice ActiveDevice { [Bind ("getActiveDevice")] get; [Bind ("setActiveDevice:")] set; }
//
//		// @required -(void)setConfig:(NSString *)val forKey:(ooVooVideoControllerConfigKey)key;
//		//		[Abstract]
//		[Export ("setConfig:forKey:")]
//		void SetConfig (string val, ooVooVideoControllerConfigKey key);
//
//		// @required -(NSString *)getConfig:(ooVooVideoControllerConfigKey)key;
//		//		[Abstract]
//		[Export ("getConfig:")]
//		string GetConfig (ooVooVideoControllerConfigKey key);
//
//		// @required -(void)openPreview;
//		//		[Abstract]
//		[Export ("openPreview")]
//		void OpenPreview ();
//
//		// @required -(void)closePreview;
//		//		[Abstract]
//		[Export ("closePreview")]
//		void ClosePreview ();
//
//		// @required -(void)openCamera;
//		//		[Abstract]
//		[Export ("openCamera")]
//		void OpenCamera ();
//
//		// @required -(void)closeCamera;
//		//		[Abstract]
//		[Export ("closeCamera")]
//		void CloseCamera ();
//
//		// @required -(void)startTransmitVideo;
//		//		[Abstract]
//		[Export ("startTransmitVideo")]
//		void StartTransmitVideo ();
//
//		// @required -(void)stopTransmitVideo;
//		//		[Abstract]
//		[Export ("stopTransmitVideo")]
//		void StopTransmitVideo ();
//
//		// @required -(BOOL)isVideoTransmitted;
//		//		[Abstract]
//		[Export ("isVideoTransmitted")]
//		////[Verify (MethodToProperty)]
//		bool IsVideoTransmitted { get; }
//
//		// @required -(void)bindVideoRender:(NSString *)uid render:(id<ooVooVideoRender>)render;
//		//		[Abstract]
//		[Export ("bindVideoRender:render:")]
//		void BindVideoRender (string uid, ooVooVideoPanel render);
//
//		// @required -(void)unbindVideoRender:(NSString *)uid render:(id<ooVooVideoRender>)render;
//		//		[Abstract]
//		[Export ("unbindVideoRender:render:")]
//		void UnbindVideoRender (string uid, ooVooVideoRender render);
//
//		// @required -(void)registerRemoteVideo:(NSString *)uid;
//		//		[Abstract]
//		[Export ("registerRemoteVideo:")]
//		void RegisterRemoteVideo (string uid);
//
//		// @required -(void)unRegisterRemoteVideo:(NSString *)uid;
//		//		[Abstract]
//		[Export ("unRegisterRemoteVideo:")]
//		void UnRegisterRemoteVideo (string uid);
//
//		// @required -(NSArray *)getDevicesList;
//		//		[Abstract]
//		[Export ("getDevicesList")]
//		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
//		NSObject[] DevicesList { get; }
//
//		// @required -(NSArray *)getEffectsList;
//		//		[Abstract]
//		[Export ("getEffectsList")]
//		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
//		NSObject[] EffectsList { get; }
//
//		// @required -(ResolutionLevel)sizeToCameraResolutionLevel:(int)width picHeight:(int)height;
//		//		[Abstract]
//		[Export ("sizeToCameraResolutionLevel:picHeight:")]
//		ResolutionLevel SizeToCameraResolutionLevel (int width, int height);
//	}
//
//	// @protocol ooVooAVChatDelegate <NSObject>
//	[BaseType (typeof(NSObject))]
//	[Model]
//	interface ooVooAVChatDelegate
//	{
//		// @required -(void)didParticipantJoin:(id<ooVooParticipant>)participant user_data:(NSString *)user_data;
//		//		[Abstract]
//		[Export ("didParticipantJoin:user_data:")]
//		void DidParticipantJoin (ooVooParticipant participant, string user_data);
//
//		// @required -(void)didParticipantLeave:(id<ooVooParticipant>)participant;
//		//		[Abstract]
//		[Export ("didParticipantLeave:")]
//		void DidParticipantLeave (ooVooParticipant participant);
//
//		// @required -(void)didConferenceStateChange:(ooVooAVChatState)state error:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didConferenceStateChange:error:")]
//		void DidConferenceStateChange (ooVooAVChatState state, sdk_error code);
//
//		// @required -(void)didReceiveData:(NSString *)uid data:(NSData *)data;
//		//		[Abstract]
//		[Export ("didReceiveData:data:")]
//		void DidReceiveData (string uid, NSData data);
//
//		// @required -(void)didConferenceError:(sdk_error)code;
//		//		[Abstract]
//		[Export ("didConferenceError:")]
//		void DidConferenceError (sdk_error code);
//
//		// @required -(void)didNetworkReliabilityChange:(NSNumber *)score;
//		//		[Abstract]
//		[Export ("didNetworkReliabilityChange:")]
//		void DidNetworkReliabilityChange (NSNumber score);
//
//		// @required -(void)didSecurityState:(_Bool)is_secure;
//		//		[Abstract]
//		[Export ("didSecurityState:")]
//		void DidSecurityState (bool is_secure);
//	}
//
//	// @protocol ooVooAVChat <NSObject>
//	[BaseType (typeof (NSObject))]
//	[Model]
//	interface ooVooAVChat
//	{
//		[Wrap ("WeakDelegate")]
//		ooVooAVChatDelegate Delegate { get; set; }
//
//		// @required @property (retain, atomic) id<ooVooAVChatDelegate> delegate;
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
//		NSObject WeakDelegate { get; set; }
//
//		// @required @property (readonly, getter = isInCallMessagePermit, assign) BOOL isInCallMessagePermit;
//		[Export ("isInCallMessagePermit")]
//		bool IsInCallMessagePermit { [Bind ("isInCallMessagePermit")] get; }
//
//		// @required @property (readonly, getter = get_audiocontroller, retain) id<ooVooAudioController> AudioController;
//		[Export ("AudioController", ArgumentSemantic.Retain)]
//		ooVooAudioController AudioController { [Bind ("get_audiocontroller")] get; }
//
//		// @required @property (readonly, getter = get_videocontroller, retain) id<ooVooVideoController> VideoController;
//		[Export ("VideoController", ArgumentSemantic.Retain)]
//		ooVooVideoController VideoController { [Bind ("get_videocontroller")] get; }
//
//		// @required -(void)join:(NSString *)cid user_data:(NSString *)data;
//		//		[Abstract]
//		[Export ("join:user_data:")]
//		void Join (string cid, string data);
//
//		// @required -(void)leave;
//		//		[Abstract]
//		[Export ("leave")]
//		void Leave ();
//
//		// @required -(void)sendData:(NSString *)uid data:(NSData *)buffer completion:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("sendData:data:completion:")]
//		void SendData (string uid, NSData buffer, CompletionHandler completion);
//
//		// @required -(void)sendData:(NSData *)buffer completion:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("sendData:completion:")]
//		void SendData (NSData buffer, CompletionHandler completion);
//
//		// @required -(void)registerPlugin:(id<ooVooPluginFactory>)plugin completion:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("registerPlugin:completion:")]
//		void RegisterPlugin (ooVooPluginFactory plugin, CompletionHandler completion);
//
//		// @required -(void)unregisterPlugin:(id<ooVooPluginFactory>)plugin;
//		//		[Abstract]
//		[Export ("unregisterPlugin:")]
//		void UnregisterPlugin (ooVooPluginFactory plugin);
//
//		// @required -(NSString *)getUserFullName;
//		//		[Abstract]
//		[Export ("getUserFullName")]
//		////[Verify (MethodToProperty)]
//		string UserFullName { get; }
//
//		// @required -(BOOL)isResolutionSuported:(ResolutionLevel)resolution;
//		//		[Abstract]
//		[Export ("isResolutionSuported:")]
//		bool IsResolutionSuported (ResolutionLevel resolution);
//	}
//
//	// @protocol ooVooAccountDelegate <NSObject>
//	[BaseType (typeof(NSObject))]
//	//	[Model, Protocol]
//	interface ooVooAccountDelegate
//	{
//		// @required -(void)didAccountLogIn:(id<ooVooAccount>)account;
//		[Abstract]
//		[Export ("didAccountLogIn:")]
//		void DidAccountLogIn (ooVooAccount account);
//
//		// @required -(void)didAccountLogOut:(id<ooVooAccount>)account;
//		[Abstract]
//		[Export ("didAccountLogOut:")]
//		void DidAccountLogOut (ooVooAccount account);
//	}
//
//	// @protocol ooVooAccount <NSObject>
//	[BaseType (typeof (NSObject))]
//	//	[Model]
//	interface ooVooAccount
//	{
//		[Wrap ("WeakDelegate")]
//		ooVooAccountDelegate Delegate { get; set; }
//
//		// @required @property (retain, atomic) id<ooVooAccountDelegate> delegate;
//		//		[Abstract]
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
//		NSObject WeakDelegate { get; set; }
//
//		// @required @property (getter = get_uid, retain, atomic) NSString * uid;
//		//		[Abstract]
//		[Export ("uid", ArgumentSemantic.Retain)]
//		string Uid { [Bind ("get_uid")] get; set; }
//
//		// @required @property (readonly, getter = state, assign, atomic) AccountState state;
//		//		[Abstract]
//		[Export ("state", ArgumentSemantic.Assign)]
//		AccountState State { [Bind ("state")] get; }
//
//		// @required -(void)login:(NSString *)uid completion:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("login:completion:")]
//		void Login (string uid, CompletionHandler completion);
//
//		// @required -(void)logout;
//		//		[Abstract]
//		[Export ("logout")]
//		void Logout ();
//	}
//
//	// @protocol ooVooApplicationSettings <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooApplicationSettings
//	{
//		// @required -(void)setApplicationSettingsValue:(NSString *)value forKey:(ooVooApplicationSettingsProperty)key;
//		[Abstract]
//		[Export ("setApplicationSettingsValue:forKey:")]
//		void SetApplicationSettingsValue (string value, ooVooApplicationSettingsProperty key);
//
//		// @required -(NSString *)getApplicationSettingsProperty:(ooVooApplicationSettingsProperty)key;
//		[Abstract]
//		[Export ("getApplicationSettingsProperty:")]
//		string GetApplicationSettingsProperty (ooVooApplicationSettingsProperty key);
//	}
//
//	// @interface ooVooMessage : NSObject
//	[BaseType (typeof(NSObject))]
//	interface ooVooMessage
//	{
//		// @property (readonly, getter = get_from) NSString * from;
//		[Export ("from")]
//		string From { [Bind ("get_from")] get; }
//
//		// @property (readonly, getter = get_to) NSArray * to;
//		[Export ("to")]
//		//[Verify (StronglyTypedNSArray)]
//		NSObject[] To { [Bind ("get_to")] get; }
//
//		// @property (readonly, getter = get_body) NSString * body;
//		[Export ("body")]
//		string Body { [Bind ("get_body")] get; }
//
//		// @property (readonly, getter = get_messageId) NSString * messageId;
//		[Export ("messageId")]
//		string MessageId { [Bind ("get_messageId")] get; }
//
//		// @property (readonly, getter = get_timestamp) uint64_t timestamp;
//		[Export ("timestamp")]
//		ulong Timestamp { [Bind ("get_timestamp")] get; }
//
//		// -(instancetype)initMessage:(NSString *)to message:(NSString *)message;
//		[Export ("initMessage:message:")]
//		IntPtr Constructor (string to, string message);
//
//		// -(instancetype)initMessageWithData:(NSArray *)to message:(NSData *)message;
//		[Export ("initMessageWithData:message:")]
//		//[Verify (StronglyTypedNSArray)]
//		IntPtr Constructor (NSObject[] to, NSData message);
//
//		// -(instancetype)initMessageWithArrayUsers:(NSArray *)to message:(NSString *)message;
//		[Export ("initMessageWithArrayUsers:message:")]
//		//[Verify (StronglyTypedNSArray)]
//		IntPtr Constructor (NSObject[] to, string message);
//	}
//
//	// @protocol ooVooMessagingDelegate <NSObject>
//	[BaseType (typeof(NSObject))]
//	[Model]
//	interface ooVooMessagingDelegate
//	{
//		// @required -(void)didMessageReceive:(ooVooMessage *)message;
//		[Export ("didMessageReceive:")]
//		void DidMessageReceive (ooVooMessage message);
//
//		// @required -(void)didMessageReceiveAcknowledgement:(ooVooMessageAcknowledgeState)state forMessageId:(NSString *)messageId;
//		[Export ("didMessageReceiveAcknowledgement:forMessageId:")]
//		void DidMessageReceiveAcknowledgement (ooVooMessageAcknowledgeState state, string messageId);
//
//		// @required -(void)didConnectivityStateChange:(ooVooMessagingConnectivityState)state error:(sdk_error)code description:(NSString *)description;
//		[Export ("didConnectivityStateChange:error:description:")]
//		void DidConnectivityStateChange (ooVooMessagingConnectivityState state, sdk_error code, string description);
//	}
//
//	// @protocol ooVooMessaging <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooMessaging
//	{
//		[Wrap ("WeakDelegate")]
//		ooVooMessagingDelegate Delegate { get; set; }
//
//		// @required @property (retain, atomic) id<ooVooMessagingDelegate> delegate;
//		//		[Abstract]
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
//		NSObject WeakDelegate { get; set; }
//
//		// @required -(void)sendMessage:(ooVooMessage *)message completion:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("sendMessage:completion:")]
//		void SendMessage (ooVooMessage message, CompletionHandler completion);
//
//		// @required -(void)sendAcknowledgement:(ooVooMessageAcknowledgeState)state forMessage:(ooVooMessage *)message handler:(CompletionHandler)completion;
//		//		[Abstract]
//		[Export ("sendAcknowledgement:forMessage:handler:")]
//		void SendAcknowledgement (ooVooMessageAcknowledgeState state, ooVooMessage message, CompletionHandler completion);
//
//		// @required -(void)connect;
//		//		[Abstract]
//		[Export ("connect")]
//		void Connect ();
//
//		// @required -(void)disconnect;
//		//		[Abstract]
//		[Export ("disconnect")]
//		void Disconnect ();
//
//		// @required -(BOOL)isConnected;
//		//		[Abstract]
//		[Export ("isConnected")]
//		////[Verify (MethodToProperty)]
//		bool IsConnected { get; }
//	}
//
//	// @interface ooVooPushNotificationMessage : NSObject
//	[BaseType (typeof(NSObject))]
//	interface ooVooPushNotificationMessage
//	{
//		// @property (readonly, getter = get_to) NSArray * to;
//		[Export ("to")]
//		//[Verify (StronglyTypedNSArray)]
//		NSObject[] To { [Bind ("get_to")] get; }
//
//		// @property (readonly, getter = get_body) NSString * body;
//		[Export ("body")]
//		string Body { [Bind ("get_body")] get; }
//
//		// @property (readonly, getter = get_property) NSString * property;
//		[Export ("property")]
//		string Property { [Bind ("get_property")] get; }
//
//		// @property (readonly, getter = get_messageId) NSString * messageId;
//		[Export ("messageId")]
//		string MessageId { [Bind ("get_messageId")] get; }
//
//		// -(instancetype)initMessageWithUsersArray:(NSArray *)to_list message:(NSString *)body property:(NSString *)property timeToLeave:(unsigned int)ttl;
//		[Export ("initMessageWithUsersArray:message:property:timeToLeave:")]
//		//[Verify (StronglyTypedNSArray)]
//		IntPtr Constructor (NSObject[] to_list, string body, string property, uint ttl);
//	}
//
//	// @protocol ooVooPushService <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooPushService
//	{
//		// @required -(void)subscribe:(NSString *)token deviceUid:(NSString *)deviceUid completion:(CompletionHandler)completion;
//		[Abstract]
//		[Export ("subscribe:deviceUid:completion:")]
//		void Subscribe (string token, string deviceUid, CompletionHandler completion);
//
//		// @required -(void)unSubscribe:(NSString *)token deviceUid:(NSString *)deviceUid completion:(CompletionHandler)completion;
//		[Abstract]
//		[Export ("unSubscribe:deviceUid:completion:")]
//		void UnSubscribe (string token, string deviceUid, CompletionHandler completion);
//
//		// @required -(void)sendPushMessage:(ooVooPushNotificationMessage *)message completion:(CompletionHandler)completion;
//		[Abstract]
//		[Export ("sendPushMessage:completion:")]
//		void SendPushMessage (ooVooPushNotificationMessage message, CompletionHandler completion);
//	}
//
//	// @protocol ooVooClientLogger <NSObject>
//	[Protocol, Model]
//	[BaseType (typeof(NSObject))]
//	interface ooVooClientLogger
//	{
//		// @required -(void)onLog:(LogLevel)level log:(NSString *)log;
//		[Abstract]
//		[Export ("onLog:log:")]
//		void Log (LogLevel level, string log);
//	}
//
//	// @interface ooVooClient : NSObject
//	[BaseType (typeof(NSObject))]
//	//	[Model]
//	interface ooVooClient
//	{
//		// @property (getter = isSslVerifyPeer, setter = setSslVerifyPeer:) BOOL sslVerifyPeer;
//		[Export ("sslVerifyPeer")]
//		bool SslVerifyPeer { [Bind ("isSslVerifyPeer")] get; [Bind ("setSslVerifyPeer:")] set; }
//
//		// @property (readonly, getter = IsAuthorized, atomic) BOOL IsAuthorized;
//		[Export ("IsAuthorized")]
//		bool IsAuthorized { [Bind ("IsAuthorized")] get; }
//
//		// @property (readonly, getter = app_token, atomic) NSString * ApplicationToken;
//		[Export ("ApplicationToken")]
//		string ApplicationToken { [Bind ("app_token")] get; }
//
//		// @property (readonly, getter = Account, atomic) id<ooVooAccount> Account;
//		[Export ("Account")]
//		ooVooAccount Account { [Bind ("Account")] get; }
//
//		// @property (readonly, getter = AVChat, atomic) id<ooVooAVChat> AVChat;
//		[Export ("AVChat")]
//		ooVooAVChat AVChat { [Bind ("AVChat")] get; }
//
//		// @property (readonly, getter = PushService, atomic) id<ooVooPushService> PushService;
//		[Export ("PushService")]
//		ooVooPushService PushService { [Bind ("PushService")] get; }
//
//		// @property (readonly, getter = Messaging, atomic) id<ooVooMessaging> Messaging;
//		[Export ("Messaging")]
//		ooVooMessaging Messaging { [Bind ("Messaging")] get; }
//
//		// +(void)setLogger:(id<ooVooClientLogger>)logger;
//		[Static]
//		[Export ("setLogger:")]
//		void SetLogger (ooVooClientLogger logger);
//
//		// +(void)setLogLevel:(LogLevel)level;
//		[Static]
//		[Export ("setLogLevel:")]
//		void SetLogLevel (LogLevel level);
//
//		// +(ooVooClient *)sharedInstance;
//		[Static]
//		[Export ("sharedInstance")]
//		////[Verify (MethodToProperty)]
//		ooVooClient SharedInstance { get; }
//
//		// +(void)applicationDidEnterBackground;
//		[Static]
//		[Export ("applicationDidEnterBackground")]
//		void ApplicationDidEnterBackground ();
//
//		// +(void)applicationWillResignActive;
//		[Static]
//		[Export ("applicationWillResignActive")]
//		void ApplicationWillResignActive ();
//
//		// +(void)applicationWillEnterForeground;
//		[Static]
//		[Export ("applicationWillEnterForeground")]
//		void ApplicationWillEnterForeground ();
//
//		// +(void)applicationDidBecomeActive;
//		[Static]
//		[Export ("applicationDidBecomeActive")]
//		void ApplicationDidBecomeActive ();
//
//		// -(void)authorizeClient:(NSString *)app_token completion:(CompletionHandler)completion;
//		[Export ("authorizeClient:completion:")]
//		void AuthorizeClient (string app_token, CompletionHandler completion);
//
//		// -(void)setClientVersion:(NSString *)client_version;
//		[Export ("setClientVersion:")]
//		void SetClientVersion (string client_version);
//
//		// +(NSString *)getSdkVersion;
//		[Static]
//		[Export ("getSdkVersion")]
//		////[Verify (MethodToProperty)]
//		string SdkVersion { get; }
//
//		// -(void)updateConfig:(CompletionHandler)completion;
//		[Export ("updateConfig:")]
//		void UpdateConfig (CompletionHandler completion);
//	}
//
//	// @interface ooVooVideoPanel : UIView <ooVooVideoRender>
//	[BaseType (typeof(UIView))]
//	interface ooVooVideoPanel : ooVooVideoRender
//	{
//		// @property (assign, nonatomic) BOOL isVideoRenderStarted;
//		[Export ("isVideoRenderStarted")]
//		bool IsVideoRenderStarted { get; set; }
//
//		// @property (getter = fitVideoMode, nonatomic, setter = set_fitVideoMode:) BOOL fitVideoMode;
//		[Export ("fitVideoMode")]
//		bool FitVideoMode { [Bind ("fitVideoMode")] get; [Bind ("set_fitVideoMode:")] set; }
//
//		// -(void)didVideoRenderStart;
//		[Export ("didVideoRenderStart")]
//		void DidVideoRenderStart ();
//
//		// -(void)didVideoRenderStop;
//		[Export ("didVideoRenderStop")]
//		void DidVideoRenderStop ();
//	}

	//	[Static]
	////	[Verify (ConstantsInterfaceAssociation)]
	//	partial interface Constants
	//	{
	//		// extern int oovoo;
	//		[Field ("oovoo", "__Internal")]
	//		int oovoo { get; }
	//	}
}
