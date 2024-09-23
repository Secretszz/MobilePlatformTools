// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		AndroidBridgeImpl.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 19:58:39
// *******************************************

#if UNITY_ANDROID
namespace MobilePlatformTools
{
	using System;
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class AndroidBridgeImpl : IBridge
	{
		private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
		private const string ManagerClassName = "com.platform.tools.MobilePlatformTools";
		private static AndroidJavaObject api;
		private static AndroidJavaObject currentActivity;

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="option">初始化参数</param>
		void IBridge.Init(InitializationOption option)
		{
			AndroidJavaClass unityPlayer = new AndroidJavaClass(UnityPlayerClassName);
			currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

			AndroidJavaClass jc = new AndroidJavaClass(ManagerClassName);
			api = jc.CallStatic<AndroidJavaObject>("getInstance");
			api.Call("initMobilePlatformTools", currentActivity, option);
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="option">振动参数</param>
		void IBridge.Vibrator(VibratorOption option)
		{
			api.Call("vibratorByEffectType", GetVibratorEffectName(option.effectType), option);
		}

		/// <summary>
		/// 获取国家信息
		/// </summary>
		/// <param name="option">参数</param>
		void IBridge.GetCountryInfo(GetCountryInfoOption option)
		{
			api.Call("getCountryInfo", option);
		}

		/// <summary>
		/// 转换到java的VibratorEffectType对象
		/// </summary>
		/// <param name="effectType"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private string GetVibratorEffectName(VibratorEffectType effectType)
		{
			switch (effectType)
			{
				case VibratorEffectType.Low:
					return "LOW";
				case VibratorEffectType.Middle:
					return "MIDDLE";
				case VibratorEffectType.High:
					return "HIGH";
				default:
					throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
			}
		}
	}
}
#endif