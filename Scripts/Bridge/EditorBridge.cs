// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		EditorBridge.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/20 20:54:37
// *******************************************

namespace MobilePlatformTools
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class EditorBridge : IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener">初始化回调</param>
		void IBridge.Init(IBridgeListener listener)
		{
			listener?.OnCallback(0, "success", "");
		}

		/// <summary>
		/// 振动
		/// </summary>
		/// <param name="effectType">振动类型</param>
		void IBridge.Vibrator(VibratorEffectType effectType)
		{
			Debug.Log("effectType===" + effectType);
		}
	}
}