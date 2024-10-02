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
    resp.data = obj;
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
    if (_data != nil){
        [dictionary setObject:_data forKey:@"data"];
    }
    NSError* error;
    NSData* jsonData = [NSJSONSerialization dataWithJSONObject:dictionary options:NSJSONWritingPrettyPrinted error:&error];
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

+ (void)vibrator:(int)effectType
        callback:(MobilePlatformTools_BridgeCallback)callback {
    UIImpactFeedbackGenerator* generator;
    if (effectType == VibratorEffectTypeLow) {
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleLight];
    } else if (effectType == VibratorEffectTypeHigh){
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleHeavy];
    } else {
        generator = [[UIImpactFeedbackGenerator alloc]initWithStyle:UIImpactFeedbackStyleMedium];
    }

    [generator impactOccurred];
    Response* resp = [Response successWithData:[NSNumber numberWithInt:effectType]];
    callback([[resp toJson] UTF8String]);
}

+(void)getCountryInfo:(MobilePlatformTools_BridgeCallback)callback{
    NSURL* url = [NSURL URLWithString:@"https://api.ipify.org?format=json"];
    NSError* error = nil;
    NSMutableString* ip = [NSMutableString stringWithContentsOfURL:url
                                                          encoding:NSUTF8StringEncoding
                                                             error:&error];
    NSData* data = [ip dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary* dict = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingMutableContainers error:&error];
    
    url = [NSURL URLWithString:[NSString stringWithFormat:@"https://ipinfo.io/%@/json", [dict objectForKey:@"ip"]]];
    ip = [NSMutableString stringWithContentsOfURL:url encoding:NSUTF8StringEncoding error:&error];
    Response* resp = [Response successWithData:ip];
    callback([[resp toJson] UTF8String]);
}

@end

#pragma mark extern function

extern "C" void c_platform_tools_init(MobilePlatformTools_BridgeCallback callback){
    [MobilePlatformTools init:callback];
}

extern "C" void c_platform_tools_vibrator(int effectType,
                                          MobilePlatformTools_BridgeCallback callback){
    [MobilePlatformTools vibrator:effectType callback:callback];
}

extern "C" void c_platform_tools_getCountryInfo(MobilePlatformTools_BridgeCallback callback){
    [MobilePlatformTools getCountryInfo:callback];
}
