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
	using AOT;
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
			Callback.Option = option;
			c_platform_tools_init(Callback.OnResponse);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		void IBridge.Vibrator(VibratorOption option)
		{
			Callback.Option = option;
			c_platform_tools_vibrator((int)option.effectType, Callback.OnResponse);
		}

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="option">参数</param>
		void IBridge.GetCountryInfo(GetCountryInfoOption option)
		{
			Callback.Option = option;
			c_platform_tools_getCountryInfo(Callback.OnResponse);
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

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="callback">调用回调</param>
		[DllImport("__Internal")]
		private static extern void c_platform_tools_getCountryInfo(BridgeCallback callback);
		
		/// <summary>
		/// 桥接通信回调
		/// </summary>
		/// <param name="response">回调数据</param>
		private delegate void BridgeCallback(string response);

		private static class Callback
		{
			/// <summary>
			/// 分享回调监听
			/// </summary>
			public static IBaseOption Option;

			/// <summary>
			/// 支付成功回调桥接函数
			/// </summary>
			/// <param name="response"></param>
			[MonoPInvokeCallback(typeof(BridgeCallback))]
			public static void OnResponse(string response)
			{
				Option.OnResponse(response);
			}
		}
	}
}
#endif