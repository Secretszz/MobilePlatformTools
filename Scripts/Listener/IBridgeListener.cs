
// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		IBridgeListener.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 20:01:52
// *******************************************

namespace MobilePlatformTools
{
	/// <summary>
	/// 通信回调
	/// </summary>
	public interface IBridgeListener
	{
		/// <summary>
		/// 通信回调
		/// </summary>
		/// <param name="errCode">回调码</param>
		/// <param name="errMsg">回调信息</param>
		/// <param name="data">回调数据</param>
		void OnCallback(int errCode, string errMsg, string data);
	}
}