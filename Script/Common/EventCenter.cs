using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter  {
    private static Dictionary<GameEventType, Delegate> eventDic = new Dictionary<GameEventType, Delegate>();

    private static void OnListenerAdding(GameEventType eventType,Delegate callBack) {
        if (!eventDic.ContainsKey(eventType))
        {
            eventDic.Add(eventType, null);
        }
        Delegate d = eventDic[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(String.Format("尝试为事件添加不同类型的委托,当前事件所对应的委托为{1}，要添加的委托类型为{2}", eventType.GetType(), callBack.GetType()));
        }
    }

    private static void OnListenerRemoving(GameEventType eventType, Delegate callBack) {
        if (eventDic.ContainsKey(eventType))//判断存在所要移除键时，所存在的错误情况，并抛出错误
        {
            Delegate d = eventDic[eventType];
            if (d == null)
            {
                throw new Exception(String.Format("移除错误：移除委托为空，移除委托类型为{1}", eventType.GetType()));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(String.Format("移除错误：移除委托类型不匹配，所要移除委托类型为{1}", eventType.GetType()));
            }
            //eventDic.Remove(eventType);
        }
        else
        {//若所要移除的键，不存在直接返回错误
            throw new Exception(String.Format("移除错误：不存在所要移除的键，所要移除的键名为{1}", eventType.GetType()));
        }
    }

    #region 添加
    //添加无参监听委托
    public static void AddListener(GameEventType eventType,CallBack callBack) {
        
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] + callBack;
    }

    //1个参数委托监听的添加
    public static void AddListener<T>(GameEventType eventType, CallBack<T> callBack)
    {
        
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] + callBack;
    }

    //2个参数委托监听的添加
    public static void AddListener<T,U>(GameEventType eventType, CallBack<T,U> callBack)
    {

        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T,U>)eventDic[eventType] + callBack;
    }

    //3个参数委托监听的添加
    public static void AddListener<T, U,V>(GameEventType eventType, CallBack<T, U,V> callBack)
    {

        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, U,V>)eventDic[eventType] + callBack;
    }

    //4个参数委托监听的添加
    public static void AddListener<T, U, V,W>(GameEventType eventType, CallBack<T, U, V,W> callBack)
    {

        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, U, V,W>)eventDic[eventType] + callBack;
    }

    //5个参数委托监听的添加
    public static void AddListener<T, U, V, W,X>(GameEventType eventType, CallBack<T, U, V, W,X> callBack)
    {

        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, U, V, W,X>)eventDic[eventType] + callBack;
    }

    //添加无参,一个返回值监听委托
    public static void AddListener<T>(GameEventType eventType, CallBack_Return<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack_Return<T>)eventDic[eventType] + callBack;
    }

    #endregion

    #region 移除
    //无参监听委托的移除
    public static void RemoveListener(GameEventType eventType,CallBack callBack) {
        
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] - callBack;
        if (eventDic[eventType]==null) {
            eventDic.Remove(eventType);
        }
    }

    //1个参数委托监听的移除
    public static void RemoveListener<T>(GameEventType eventType, CallBack<T> callBack)
    {
        
        OnListenerRemoving(eventType, callBack);
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    //2个参数委托监听的移除
    public static void RemoveListener<T,U>(GameEventType eventType, CallBack<T,U> callBack)
    {

        OnListenerRemoving(eventType, callBack);
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        eventDic[eventType] = (CallBack<T,U>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    //3个参数委托监听的移除
    public static void RemoveListener<T, U,V>(GameEventType eventType, CallBack<T, U,V> callBack)
    {

        OnListenerRemoving(eventType, callBack);
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        eventDic[eventType] = (CallBack<T, U,V>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    //4个参数委托监听的移除
    public static void RemoveListener<T, U, V,W>(GameEventType eventType, CallBack<T, U, V,W> callBack)
    {

        OnListenerRemoving(eventType, callBack);
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        eventDic[eventType] = (CallBack<T, U, V,W>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    //5个参数委托监听的移除
    public static void RemoveListener<T, U, V, W,X>(GameEventType eventType, CallBack<T, U, V, W,X> callBack)
    {

        OnListenerRemoving(eventType, callBack);
        //若通过以上检测则说明没有发生移除错误，则将对应委托
        eventDic[eventType] = (CallBack<T, U, V, W,X>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    //无参,单个返回值监听委托的移除
    public static void RemoveListener<T>(GameEventType eventType, CallBack_Return<T> callBack)
    {

        //若通过以上检测则说明没有发生移除错误，则将对应委托
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack_Return<T>)eventDic[eventType] - callBack;
        if (eventDic[eventType] == null)
        {
            eventDic.Remove(eventType);
        }
    }

    #endregion

    #region 广播
    //广播无参事件
    public static void Boardcast(GameEventType eventType) {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack!=null) {
                callBack();
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播1个传参的事件
    public static void Boardcast<T>(GameEventType eventType,T arg)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播2个传参的事件
    public static void Boardcast<T,U>(GameEventType eventType, T arg0,U arg1)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T,U> callBack = d as CallBack<T,U>;
            if (callBack != null)
            {
                callBack(arg0,arg1);
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播3个传参的事件
    public static void Boardcast<T, U,V>(GameEventType eventType, T arg0, U arg1,V arg2)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, U,V> callBack = d as CallBack<T, U,V>;
            if (callBack != null)
            {
                callBack(arg0, arg1,arg2);
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播4个传参的事件
    public static void Boardcast<T, U, V,W>(GameEventType eventType, T arg0, U arg1, V arg2,W arg3)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, U, V,W> callBack = d as CallBack<T, U, V,W>;
            if (callBack != null)
            {
                callBack(arg0, arg1, arg2,arg3);
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播5个传参的事件
    public static void Boardcast<T, U, V, W,X>(GameEventType eventType, T arg0, U arg1, V arg2, W arg3,X arg4)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, U, V, W,X> callBack = d as CallBack<T, U, V, W,X>;
            if (callBack != null)
            {
                callBack(arg0, arg1, arg2, arg3,arg4);
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
    }

    //广播无参事件
    public static T Boardcast<T>(GameEventType eventType)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack_Return<T> callBack = d as CallBack_Return<T>;
            if (callBack != null)
            {
                return callBack();
            }
            else
            {
                throw new Exception(String.Format("不存在对应的委托值，所要广播的委托类型为{1}", eventType.GetType()));
            }
        }
        return default(T);
    }

    #endregion

}
