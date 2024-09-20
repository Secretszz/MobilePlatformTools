
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
		/// <param name="listener">初始化回调</param>
		void Init(IBridgeListener listener);

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		void Vibrator(VibratorEffectType effectType);
	}
}