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
#if UNITY_IOS
	/// <summary>
	/// 通信回调
	/// </summary>
	/// <param name="errCode">回调码</param>
	/// <param name="errMsg">回调信息</param>
	/// <param name="data">回调数据</param>
	public delegate void BridgeCallback(int errCode, string errMsg, string data);
#else
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class BridgeCallback : AndroidJavaProxy
	{
		public BridgeCallback(IBridgeListener listener) : base("com.platform.tools.IBridgeListener")
		{
			this.listener = listener;
		}

		private IBridgeListener listener;

		/// <summary>
		/// 通信回调
		/// </summary>
		/// <param name="errCode">回调码</param>
		/// <param name="errMsg">回调信息</param>
		/// <param name="data">回调数据</param>
		public void onCallback(int errCode, string errMsg, string data)
		{
			listener.OnCallback(errCode, errMsg, data);
		}
	}
#endif
}