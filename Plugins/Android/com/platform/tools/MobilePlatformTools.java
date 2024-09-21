package com.platform.tools;

import android.app.Activity;
import android.app.Service;
import android.os.Build;
import android.os.Vibrator;

import com.google.gson.Gson;
import com.platform.tools.callback.BridgeCallback;
import com.platform.tools.response.GenericsResponse;

public class MobilePlatformTools {
    private final static String TAG = MobilePlatformTools.class.getName();

    /**
     * 单例
     * @return MobilePlatformTools单例
     */
    public static MobilePlatformTools getInstance(){
        return Holder.INSTANCE;
    }

    private static class Holder{
        public static MobilePlatformTools INSTANCE = new MobilePlatformTools();
    }

    private Vibrator vibrator;

    /**
     *
     * @param activity 主activity
     * @param onComplete 初始化回调
     */
    public void initMobilePlatformTools(Activity activity, BridgeCallback onComplete){
        vibrator = (Vibrator)activity.getApplicationContext().getSystemService(Service.VIBRATOR_SERVICE);
        onComplete.onResponse(GenericsResponse.success());
    }

    /**
     * 振动
     * @param effectName 振动类型名称
     * @param onComplete 振动回调
     */
    public void vibratorByEffectType(String effectName, BridgeCallback onComplete){
        VibratorEffectType effectType = VibratorEffectType.valueOf(effectName);
        vibrator.cancel();
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.Q){
            vibrator.vibrate(VibratorEffectType.getVibrationEffectValue(effectType));
        } else {
            vibrator.vibrate(VibratorEffectType.getVibrationEffect(effectType));
        }
        onComplete.onResponse(GenericsResponse.success());
    }
}
