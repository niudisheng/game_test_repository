using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public GameObject clearOutTime;
    public PlayerIncombat PlayerIncombat;//！！！拖入
    public static bagManager instance;
    public bag playerBag;
    public Text ItemCd;//几个道具信息
    public Text describe;
    public Text itemName;
    public Text RollTime;
    public item thisItem;

    private void Start()
    {
       
       
    }
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(this);
        }
        instance = this;
    }
     void OnEnable()//根据道具bool值判断是否要调用事件中心对应道具的函数
    {

    }  
    public void clearAllItemOnBag()//清除背包里的所有道具
    {
        for (int i = 0; i < playerBag.items.Count; i++)
        {
            playerBag.items[i].isGet = false;
        }
        playerBag.items.Clear();
    }
public  void refreshItemOnBag()//外部使用道具，则转到bag里，同时改isGet
    {
        if (playerBag.items.Count <2)
        {
            playerBag.items.Add(thisItem);
            thisItem.isGet = true;
        }
        else
        {
            clearOutTime.SetActive(true);
        }
        
    }
    public static void getItem(item thisItem)
    {
        instance.thisItem = thisItem;
          //更新信息到信息栏
        instance.ItemCd.text =instance.thisItem.Cd.ToString();
        instance.describe.text = instance.thisItem.describe.ToString();
        instance.itemName.text = instance.thisItem.Name.ToString();
        instance.RollTime.text = instance.thisItem.RollTime.ToString();
    }
}
