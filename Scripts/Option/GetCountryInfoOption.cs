// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		GetCountryInfoOption.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/21 19:18:48
// *******************************************

namespace MobilePlatformTools
{
	using System;

	/// <summary>
	/// 
	/// </summary>
	public class GetCountryInfoOption : BaseOption<CountryInfoResponse>
	{

	}

	[Serializable]
	public class CountryInfoResponse : BaseResponse<CountryInfo>
	{
		
	}

	public class CountryInfo
	{
		public string ip;
		public string city;
		public string region;
		public string country;
		public string loc;
		public string org;
		public string postal;
		public string timezone;
		public string readme;
	}
}