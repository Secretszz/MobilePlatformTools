// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		VibratorOption.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/21 10:02:10
// *******************************************

namespace MobilePlatformTools
{
	using System;

	/// <summary>
	/// 
	/// </summary>
	public class VibratorOption : BaseOption<VibratorEffectType>
	{
		public VibratorEffectType effectType;
	}

	public enum VibratorEffectType
	{
		Low = 1,
		Middle = 2,
		High = 3
	}
}