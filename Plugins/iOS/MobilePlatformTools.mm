//
//  MobilePlatformTools.m
//  UnityFramework
//
//  Created by 晴天 on 2024/9/21.
//

#import <UIKit/UIImpactFeedbackGenerator.h>
#import "MobilePlatformTools.h"

#pragma mark - Response

@implementation Response

+ (instancetype)success {
    Response* resp = [[Response alloc] init];
    resp.code = [NSNumber numberWithInt:ResponseCodeSuccess];
    resp.message = ResponseMessageSuccess;
    return resp;
}

+ (instancetype)successWithData:(id)obj {
    Response* resp = [[Response alloc] init];
    resp.code = [NSNumber numberWithInt:ResponseCodeSuccess];
    resp.message = ResponseMessageSuccess;
    NSString *data = @"";
    if (obj != nil){
        NSError *error = nil;
        NSData *jsonData = [NSJSONSerialization dataWithJSONObject:data
                                                           options:0
                                                             error:&error];
        if ([jsonData length] && error == nil){
            data = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        }
    }
    resp.data = data;
    return resp;
}

+ (instancetype)error:(NSString *)message {
    Response* resp = [[Response alloc] init];
    resp.code = [NSNumber numberWithInt:ResponseCodeError];
    resp.message = message;
    return resp;
}

+ (instancetype)errorWithNSError:(NSError *)error {
    Response* resp = [[Response alloc] init];
    resp.code = [NSNumber numberWithInteger:error.code];
    resp.message = [NSString stringWithFormat:@"%@", error];
    return resp;
}

-(NSString*) toJson{
    NSMutableDictionary* dictionary = [NSMutableDictionary dictionary];
    [dictionary setObject:_code forKey:@"code"];
    [dictionary setObject:_message forKey:@"message"];
    [dictionary setObject:_data forKey:@"data"];
    NSError* error;
    NSData* jsonData = [NSJSONSerialization dataWithJSONObject:self options:NSJSONWritingPrettyPrinted error:&error];
    NSString* jsonString;
    if (!jsonData) {
        NSLog(@"%@", error);
    } else{
        jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    }
    return jsonString;
}

- (void)setCode:(NSNumber *)code {
    _code = code;
}

- (void)setData:(NSString *)data {
    _data = data;
}

- (void)setMessage:(NSString *)message {
    _message = message;
}

@end

#pragma mark - MobilePlatformTools

@implementation MobilePlatformTools

+(void)init:(MobilePlatformTools_BridgeCallback)callback {
    Response* resp = [Response success];
    callback([[resp toJson] UTF8String]);
}

+ (void)vibrator:(UIImpactFeedbackStyle)style
        callback:(MobilePlatformTools_BridgeCallback)callback {
    UIImpactFeedbackGenerator* generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:style];
    [generator impactOccurred];
}

@end

#pragma mark extern function

extern "C" void c_platform_tools_init(MobilePlatformTools_BridgeCallback callback){
    [MobilePlatformTools init:callback];
}

extern "C" void c_platform_tools_vibrator(int effectType,
                                          MobilePlatformTools_BridgeCallback callback){
    if (effectType == VibratorEffectTypeLow) {
        [MobilePlatformTools vibrator:UIImpactFeedbackStyleLight callback:callback];
    } else if (effectType == VibratorEffectTypeMiddle){
        [MobilePlatformTools vibrator:UIImpactFeedbackStyleMedium callback:callback];
    } else if (effectType == VibratorEffectTypeHigh){
        [MobilePlatformTools vibrator:UIImpactFeedbackStyleHeavy callback:callback];
    } else {
        Response* resp = [Response error:[NSString stringWithFormat:@"Unknown vibrator effect type: %d", effectType]];
    }
}
