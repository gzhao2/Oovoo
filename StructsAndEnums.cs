namespace Oovoo
{
	public enum sdk_error
	{
		Ok = 0,
		InvalidParameter = 1,
		InvalidPointer = 2,
		InvalidOperation = 3,
		MethodNotImplemented = 4,
		DeviceNotFound = 5,
		AlreadyInSession = 6,
		DuplicateParticipantId = 7,
		ConferenceIdNotValid = 8,
		ClientIdNotValid = 9,
		ParticipantIdNotValid = 10,
		CameraIdNotValid = 11,
		MicrophoneIdNotValid = 12,
		SpeakerIdNotValid = 13,
		VolumeNotValid = 14,
		ServerAddressNotValid = 15,
		GroupQuotaExceeded = 16,
		NotInitialized = 17,
		Error = 18,
		NotAuthorized = 19,
		ConnectionTimeout = 20,
		DisconnectedByPeer = 21,
		InvalidToken = 22,
		ExpiredToken = 23,
		PreviousOperationNotCompleted = 24,
		AppIdNotValid = 25,
		NoAvs = 26,
		ActionNotPermitted = 27,
		DeviceNotInitialized = 28,
		Reconnecting = 29,
		Held = 30,
		SSLCertificateVerificationFailed = 31,
		ParameterAlreadySet = 32,
		AccessDenied = 33,
		ConnectionLost = 34,
		NotEnoughMemory = 35,
		ResolutionNotSupported = 36,
		AuthenticationFailed = 37,
		ApiVersionNotFound = 38,
		CreateGroupFailed = 39,
		InvalidContentType = 40,
		UnsupportedContentType = 41
	}

	public enum GenderType
	{
		Female,
		Male
	}

	public enum AccountState
	{
		In,
		Out
	}

	public enum LogLevel
	{
		None = 0,
		Fatal = 1,
		Error = 2,
		Warning = 3,
		Info = 4,
		Debug = 5,
		Trace = 6,
		Sample = 7
	}

	public enum ooVooFriendPresence
	{
		Availabe = 2,
		Busy = 1,
		Away = 4,
		Invisible,
		Unavailable
	}

	public enum FriendNegotationType
	{
		Undefined,
		Subscribe,
		Subscribed,
		Unsubscribe,
		Unsubscribed
	}

	public enum ooVooDeviceState
	{
		NotCreated,
		TurningOn,
		TurnedOn,
		TurningOff,
		TurnedOff,
		Restarting,
		OnHold
	}

	public enum ooVooAudioRouteType
	{
		ToEarpiece = 0,
		RouteToHeadphones = 1,
		RouteToBluetooth = 2,
		RouteToSpeaker
	}

	public enum ooVooVideoControllerConfigKey
	{
		CaptureDeviceId,
		Resolution,
		Fps,
		EffectId
	}

	public enum ResolutionLevel
	{
		NotSpecified = 0,
		Low = 1,
		Med = 2,
		High = 3,
		Hd = 4
	}

	public enum ooVooPstnState
	{
		StartCall,
		EndCall,
		InProgress,
		Ringing,
		CallIsBeingForwarded,
		Queued,
		SessionInProgress,
		Ok,
		BadRequest,
		PaymentRequired,
		NotFound,
		RequestTimedOut,
		ConnectionTimedOut,
		TooManyPstnClients,
		InvalidPhoneNumber,
		InfrastructureError
	}

	public enum ooVooAudioControllerConfigKey
	{
		RenderDeviceId,
		CaptureDeviceId,
		AudioSetMode
	}

	public enum ooVooAVChatState
	{
		Joined,
		Disconnected
	}

	public enum ooVooAVChatRemoteVideoState
	{
		Started,
		Stopped,
		Paused,
		Resumed
	}

	public enum ooVooAVParticipantType
	{
		Voip,
		Pstn
	}

	public enum ooVooColorFormat
	{
		None = -1,
		Yv12 = 100,
		Nv12,
		Nv21,
		Yuy2,
		Uyvy,
		Yuv420,
		Rgb32,
		Rgb24,
		Bgr32,
		Bgr24,
		Gray,
		Yuv420a,
		Yuv444a,
		Graya,
		Surface,
		Raw
	}

	public enum ooVooApplicationSettingsProperty
	{
		MaxParticipantsInCall,
		EnableInviteInExisitingCall,
		AvchatExclusiveMode,
		AvatarMaxSizeKb,
		VideoMaxSizeKb
	}

	public enum ooVooMessageAcknowledgeState
	{
		Delivered,
		Read
	}

	public enum ooVooMessagingConnectivityState
	{
		Connected,
		Disconnected
	}
}
