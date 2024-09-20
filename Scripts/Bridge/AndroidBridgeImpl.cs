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
		private static AndroidJavaClass VibratorEffectType;

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener">初始化回调</param>
		void IBridge.Init(IBridgeListener listener)
		{
			AndroidJavaClass unityPlayer = new AndroidJavaClass(UnityPlayerClassName);
			currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

			AndroidJavaClass jc = new AndroidJavaClass(ManagerClassName);
			api = jc.CallStatic<AndroidJavaObject>("getInstance");
			api.Call("initMobilePlatformTools", currentActivity, listener);
			
			VibratorEffectType = new AndroidJavaClass("com.platform.tools.VibratorEffectType");
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		void IBridge.Vibrator(VibratorEffectType effectType)
		{
			api.Call("vibratorByEffectType", GetVibratorEffectType(effectType));
		}

		/// <summary>
		/// 转换到java的VibratorEffectType对象
		/// </summary>
		/// <param name="effectType"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		private AndroidJavaObject GetVibratorEffectType(VibratorEffectType effectType)
		{
			switch (effectType)
			{
				case MobilePlatformTools.VibratorEffectType.Low:
					return VibratorEffectType.GetStatic<AndroidJavaObject>("LOW");
				case MobilePlatformTools.VibratorEffectType.Middle:
					return VibratorEffectType.GetStatic<AndroidJavaObject>("MIDDLE");
				case MobilePlatformTools.VibratorEffectType.High:
					return VibratorEffectType.GetStatic<AndroidJavaObject>("HIGH");
				default:
					throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
			}
		}
	}
}
#endif