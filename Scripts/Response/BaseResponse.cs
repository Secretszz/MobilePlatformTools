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
	using System;

	[Serializable]
	public class BaseResponse
	{
		public int code;
		public string msg;
	}

	/// <summary>
	/// 
	/// </summary>
	public class BaseResponse<T> : BaseResponse
	{
		public T data;
	}
}