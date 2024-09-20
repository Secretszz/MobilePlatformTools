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
		/// <param name="listener">初始化回调</param>
		public static void Init(IBridgeListener listener)
		{
			Bridge.Init(listener);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		public static void Vibrator(VibratorEffectType effectType)
		{
			Bridge.Vibrator(effectType);
		}
	}

	public enum VibratorEffectType
	{
		Low = 1,
		Middle = 2,
		High = 3
	}
}