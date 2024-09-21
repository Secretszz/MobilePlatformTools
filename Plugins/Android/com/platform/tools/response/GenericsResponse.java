package com.platform.tools.response;

import com.google.gson.Gson;

public class GenericsResponse<T> {
    public final static int CODE_SUCCESS = 0;
    public final static String MESSAGE_SUCCESS = "success";
    public final static int CODE_ERROR = -1;

    public int code;
    public String message;
    public T data;

    /**
     * 无数据成功响应
     * @return 回调json数据
     */
    public static <T> String success(){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = CODE_SUCCESS;
        response.message = MESSAGE_SUCCESS;
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
        response.code = CODE_SUCCESS;
        response.message = MESSAGE_SUCCESS;
        response.data = data;
        Gson gson = new Gson();
        return gson.toJson(response);
    }

    /**
     * 无数据失败响应
     * @param message 错误信息
     * @return 回调json数据
     */
    public static <T> String error(String message){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = CODE_ERROR;
        response.message = message;
        Gson gson = new Gson();
        return gson.toJson(response);
    }

    /**
     * 无数据失败响应
     * @param exception 错误信息
     * @return 回调json数据
     */
    public static <T> String error(RuntimeException exception){
        GenericsResponse<T> response = new GenericsResponse<>();
        response.code = CODE_ERROR;
        response.message = exception.getMessage();
        Gson gson = new Gson();
        return gson.toJson(response);
    }
}
