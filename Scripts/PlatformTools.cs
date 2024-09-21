// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		PlatformTools.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 19:54:01
// *******************************************

namespace MobilePlatformTools
{
	/// <summary>
	/// 
	/// </summary>
	public static class PlatformTools
	{
		public const string RESPONSE_PROPERTY_NAME_CODE = "code";
		public const string RESPONSE_PROPERTY_NAME_MSG = "msg";
		public const string RESPONSE_PROPERTY_NAME_DATA = "data";
		public const int RESPONSE_CODE_SUCCESS = 0;
		public const int RESPONSE_CODE_ERROR = -1;
		
		private static IBridge _bridge;

		private static IBridge Bridge
		{
			get
			{
				if (_bridge == null)
				{
#if UNITY_IOS && !UNITY_EDITOR
					_bridge = new iOSBridgeImpl();
#elif UNITY_ANDROID && !UNITY_EDITOR
					_bridge = new AndroidBridgeImpl();
#else
					_bridge = new EditorBridge();
#endif
				}

				return _bridge;
			}
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="option">初始化参数</param>
		public static void Init(InitializationOption option)
		{
			Bridge.Init(option);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		public static void Vibrator(VibratorOption option)
		{
			Bridge.Vibrator(option);
		}
	}
}