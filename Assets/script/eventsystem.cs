using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class eventsystem : baseNomonoManager<eventsystem>
{
    Dictionary<string, UnityAction> events = new Dictionary<string, UnityAction>();
    //添加事件的函数
    public void setUp(string name,UnityAction action)
    {
        //判断是否存在该key
        if(events.ContainsKey(name))
        {
            events[name] += action;
        }
        else
        {
            events.Add(name, action);
        }
    }
    //调用的函数
    public void EventInvoke(string name)
    {
        if(events.ContainsKey(name))
        {
            events[name].Invoke();
        }
    }
    //删除事件
    public void deleteEvent(string name,UnityAction action)
    {
        if(events.ContainsKey(name))
        {
            events[name] -= action;
        }
    }
    public void clearKey(string name)
    {
        if(events.ContainsKey(name))
        {
            events.Remove(name);
        }
    }
    public void clearAll()
    {
        events.Clear();
    }
}
