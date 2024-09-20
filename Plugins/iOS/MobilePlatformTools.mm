//
//  MobilePlatformTools.mm
//  Unity-iPhone
//

#import <UIKit/UIImpactFeedbackGenerator.h>

typedef void(* BridgeCallback)(int, const char *, const char *);

extern "C" void c_platform_tools_init(BridgeCallback callback)
{
	callback(0, "success", "");
}

extern "C" void c_platform_tools_vibrator(int effectType)
{
    UIImpactFeedbackGenerator * generator;
    if (Type == 0)
    {
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleLight];
    }
    else if (Type == 1)
    {
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleMedium];
    }
    else
    {
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleHeavy];
    }
    [generator impactOccurred];
}