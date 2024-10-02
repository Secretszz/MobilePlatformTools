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

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="option">参数</param>
		public static void GetCountryInfo(GetCountryInfoOption option)
		{
			Bridge.GetCountryInfo(option);
		}
	}
}