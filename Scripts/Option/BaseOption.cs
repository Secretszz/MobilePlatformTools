// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		BridgeCallback.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 20:02:12
// *******************************************

namespace MobilePlatformTools
{
	using UnityEngine;
	using Newtonsoft.Json;

	/// <summary>
	/// 桥接通信回调
	/// </summary>
	/// <param name="response">回调数据</param>
	public delegate void BridgeCallback(string response);

	/// <summary>
	/// 结果回调
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public delegate void ResponseCallback<in T>(T response) where T : BaseResponse;

	/// <summary>
	/// 
	/// </summary>
	public class BaseOption<T>
#if UNITY_ANDROID
	 : AndroidJavaProxy
#endif
			where T : BaseResponse
	{
#if UNITY_ANDROID
		protected BaseOption() : base("com.platform.tools.BridgeCallback"){}
#endif

		public ResponseCallback<T> response { private get; set; }

		/// <summary>
		/// 通信回调
		/// </summary>
		/// <param name="data">回调数据</param>
#if UNITY_IOS
		[AOT.MonoPInvokeCallback(typeof(BridgeCallback))]
#endif
		public void onResponse(string data)
		{
			response?.Invoke(JsonConvert.DeserializeObject<T>(data));
		}
	}
}