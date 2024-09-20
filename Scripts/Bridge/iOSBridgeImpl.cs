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
	using AOT;

	/// <summary>
	/// 
	/// </summary>
	public class iOSBridgeImpl : IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener">初始化回调</param>
		void IBridge.Init(IBridgeListener listener)
		{
			c_platform_tools_init(InitCallback);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		void IBridge.Vibrator(VibratorEffectType effectType)
		{
			c_platform_tools_vibrator((int)effectType);
		}

		private static IBridgeListener _initListener;

		/// <summary>
		/// 初始化
		/// </summary>
		[DllImport("__Internal")]
		private static extern void c_platform_tools_init(BridgeCallback callback);

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		[DllImport("__Internal")]
		private static extern void c_platform_tools_vibrator(int effectType);

		/// <summary>
		/// 初始化回调
		/// </summary>
		/// <param name="errCode">回调码</param>
		/// <param name="errMsg">回调信息</param>
		/// <param name="data">回调数据</param>
		[MonoPInvokeCallback(typeof(BridgeCallback))]
		public static void InitCallback(int errCode, string errMsg, string data)
		{
			_initListener?.OnCallback(errCode, errMsg, data);
		}
	}
}
#endif