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
	using System;
	using Newtonsoft.Json;

	public interface IBaseOption
	{
		public const int CODE_SUCCESS = 1;
		public const int CODE_CANCEL = 0;
		void OnResponse(string response);
	}

	/// <summary>
	/// 
	/// </summary>
	public abstract class BaseOption<T> : IBaseOption
	{
		public event Action<T> onSuccess; 
		public event Action onCancel; 
		public event Action<int, string> onError; 

		/// <summary>
		/// 通信回调
		/// </summary>
		/// <param name="response">回调数据</param>
		public void OnResponse(string response)
		{
			var res = JsonConvert.DeserializeObject<Response<T>>(response);
			switch (res.code)
			{
				case IBaseOption.CODE_SUCCESS:
					onSuccess?.Invoke(res.data);
					break;
				case IBaseOption.CODE_CANCEL:
					onCancel?.Invoke();
					break;
				default:
					onError?.Invoke(res.code, res.msg);
					break;
			}
		}
	}
}