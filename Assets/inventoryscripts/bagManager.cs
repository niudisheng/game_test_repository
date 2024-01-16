using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public player player;//！！！拖入
    public static bagManager instance;
    public bag playerBag;
    private void Start()
    {
        //把道具函数初始化到事件中心
        eventsystem.Instance.setUp("daojuming", text);//此string变量和道具名字应该相同
        //使场景刷新后在前一个场景已经获取的道具生效
        for(int i=0;i<instance.playerBag.items.Count;i++)
        {
            if (instance.playerBag.items[i].isGet)
            {
                eventsystem.Instance.EventInvoke(instance.playerBag.items[i].name);
            }
        }
    }
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(this);
        }
        instance = this;
    }
     void OnEnable()//根据
    {
        
    }
    static void refreshItem()
    {
        //先删除
        for(int i=0;i<instance.bagPenel.transform.childCount;i++)
        {
            if (instance.bagPenel.transform.childCount == 0)
                break;
            Destroy(instance.bagPenel.transform.GetChild(i).gameObject);
        }
        //后更新
        for(int i=0;i<instance.playerBag.items.Count;i++)
        {
            //更新每个bag里道具的数据到UI里（数目，描述，）
        }
    }
    //下面写各个道具对玩家的影响的函数
    void text()
    {
        print("text");
    }
}
