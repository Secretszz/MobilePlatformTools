// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		iOSBridgeImpl.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 20:57:03
// *******************************************

#if UNITY_IOS
namespace MobilePlatformTools
{
	using System.Runtime.InteropServices;

	/// <summary>
	/// 
	/// </summary>
	public class iOSBridgeImpl : IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="option">初始化参数</param>
		void IBridge.Init(InitializationOption option)
		{
			c_platform_tools_init(option.onResponse);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		void IBridge.Vibrator(VibratorOption option)
		{
			c_platform_tools_vibrator((int)option.effectType, option.onResponse);
		}

		/// <summary>
		/// /初始化
		/// </summary>
		/// <param name="callback">调用回调</param>
		[DllImport("__Internal")]
		private static extern void c_platform_tools_init(BridgeCallback callback);

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		/// <param name="callback">调用回调</param>
		[DllImport("__Internal")]
		private static extern void c_platform_tools_vibrator(int effectType, BridgeCallback callback);
	}
}
#endif