
// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		IBridge.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 19:54:19
// *******************************************

namespace MobilePlatformTools
{
	/// <summary>
	/// 
	/// </summary>
	public interface IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="option">初始化参数</param>
		void Init(InitializationOption option);

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		void Vibrator(VibratorOption option);

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="option">参数</param>
		void GetCountryInfo(GetCountryInfoOption option);
	}
}