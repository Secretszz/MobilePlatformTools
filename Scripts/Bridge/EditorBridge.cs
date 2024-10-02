// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		EditorBridge.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 20:54:37
// *******************************************

#if UNITY_EDITOR

namespace MobilePlatformTools
{
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// 
	/// </summary>
	public class EditorBridge : IBridge
	{
		private const string RESPONSE_PROPERTY_NAME_CODE = "code";
		private const string RESPONSE_PROPERTY_NAME_MSG = "msg";
		private const string RESPONSE_PROPERTY_NAME_DATA = "data";
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="option">初始化参数</param>
		void IBridge.Init(InitializationOption option)
		{
			JObject response = new JObject();
			response[RESPONSE_PROPERTY_NAME_CODE] = 0;
			response[RESPONSE_PROPERTY_NAME_MSG] = "editor";
			option.OnResponse(response.ToString());
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		void IBridge.Vibrator(VibratorOption option)
		{
			JObject response = new JObject();
			response[RESPONSE_PROPERTY_NAME_CODE] = 0;
			response[RESPONSE_PROPERTY_NAME_MSG] = "editor";
			response[RESPONSE_PROPERTY_NAME_DATA] = option.effectType.ToString();
			option.OnResponse(response.ToString());
		}

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="option">参数</param>
		void IBridge.GetCountryInfo(GetCountryInfoOption option)
		{
			JObject response = new JObject();
			response[RESPONSE_PROPERTY_NAME_CODE] = 0;
			response[RESPONSE_PROPERTY_NAME_MSG] = "editor";
			response[RESPONSE_PROPERTY_NAME_DATA] = JObject.FromObject(new CountryInfo
			{
					ip = "154.21.193.43",
					city = "Los Angeles",
					region = "California",
					country = "US",
					loc = "34.0522,-118.2437",
					org = "AS174 Cogent Communications",
					postal = "90009",
					timezone = "America/Los_Angeles",
					readme = "https://ipinfo.io/missingauth"
			});
			option.OnResponse(response.ToString());
		}
	}
}
#endif