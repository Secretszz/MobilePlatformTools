// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		BaseResponse.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/21 10:30:13
// *******************************************

namespace MobilePlatformTools
{
	using Newtonsoft.Json;
	using System;

	/// <summary>
	/// 与移动平台通信回复
	/// </summary>
	[Serializable]
	public class Response<T>
	{
		public int code;
		public string msg;
		public T data;
		
		public static string Success()
		{
			return JsonConvert.SerializeObject(new Response<T>
			{
					code = IBaseOption.CODE_SUCCESS,
					msg = "success"
			});
		}

		public static string Success(T data)
		{
			return JsonConvert.SerializeObject(new Response<T>
			{
					code = IBaseOption.CODE_SUCCESS,
					msg = "success",
					data = data
			});
		}

		public static string Cancel()
		{
			return JsonConvert.SerializeObject(new Response<T>
			{
					code = IBaseOption.CODE_CANCEL,
					msg = "cancel"
			});
		}
		
		public static string Error(int code, string msg)
		{
			return JsonConvert.SerializeObject(new Response<T>
			{
					code = code,
					msg = msg
			});
		}
	}
}
