//
//  MobilePlatformTools.h
//  UnityFramework
//
//  Created by 晴天 on 2024/9/21.
//

#pragma mark - Callback define
typedef void(* MobilePlatformTools_BridgeCallback)(const char *);


#pragma mark - Constant

static int ResponseCodeSuccess = 0;
static int ResponseCodeError = -1;
static NSString* ResponseMessageSuccess = @"success";
static int VibratorEffectTypeLow = 0;
static int VibratorEffectTypeMiddle = 1;
static int VibratorEffectTypeHigh = 2;

#pragma mark - Response

@interface Response : NSObject
{
    @private NSNumber* _code;
    @private NSString* _message;
    @private id _data;
}
-(void)setCode:(NSNumber*)code;
-(void)setMessage:(NSString*)message;
-(void)setData:(id)data;

+(instancetype)success;
+(instancetype)successWithData:(id) data;
+(instancetype)error:(NSString*) message;
+(instancetype)errorWithNSError:(NSError*) error;
-(NSString*) toJson;
@end

#pragma mark MobilePlatformTools

@interface MobilePlatformTools : NSObject
+(void)init:(MobilePlatformTools_BridgeCallback)callback;
+(void)vibrator:(int)effectType
       callback:(MobilePlatformTools_BridgeCallback)callback;
+(void)getCountryInfo:(MobilePlatformTools_BridgeCallback)callback;
@end
