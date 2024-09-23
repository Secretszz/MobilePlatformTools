package com.platform.tools.response;

import com.google.gson.Gson;
import com.platform.tools.MobilePlatformTools;

/**
 * 泛型响应
 * @param <T> 响应数据类型
 */
public class GenericsResponse<T> {
    /**
     * 结果代码：0成功，其它数字为失败
     */
    private int code;

    /**
     * 错误信息
     */
    private String message;

    /**
     * 响应数据
     */
    private T data;

    /**
     * 无数据成功响应
     * @return 回调json数据
     * @param <T> 响应数据类型
     */
    public static <T> String success(){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = MobilePlatformTools.CODE_SUCCESS;
        response.message = MobilePlatformTools.MESSAGE_SUCCESS;
        Gson gson = new Gson();
        return gson.toJson(response);
    }

    /**
     * 有数据成功响应
     * @param data 响应数据
     * @return 回调json数据
     * @param <T> 响应数据类型
     */
    public static <T> String success(T data){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = MobilePlatformTools.CODE_SUCCESS;
        response.message = MobilePlatformTools.MESSAGE_SUCCESS;
        response.data = data;
        Gson gson = new Gson();
        return gson.toJson(response);
    }

    /**
     * 无数据失败响应
     * @param message 错误信息
     * @return 回调json数据
     * @param <T> 响应数据类型
     */
    public static <T> String error(String message){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = MobilePlatformTools.CODE_ERROR;
        response.message = message;
        Gson gson = new Gson();
        return gson.toJson(response);
    }

    /**
     * 无数据失败响应
     * @param exception 错误信息
     * @return 回调json数据
     * @param <T> 响应数据类型
     */
    public static <T> String error(RuntimeException exception){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = MobilePlatformTools.CODE_ERROR;
        response.message = exception.getMessage();
        Gson gson = new Gson();
        return gson.toJson(response);
    }
}
