using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolMgr: baseNomonoManager<poolMgr>
{
    //创建字典柜子
    public Dictionary<string, Stack<GameObject>> poolDic = new Dictionary<string, Stack<GameObject>>();
    //获取抽屉里对象的函数

    public GameObject getObj(string name,Transform Position)
    {
        GameObject Obj;
        if (poolDic.ContainsKey(name) && poolDic[name].Count > 0)//有对象在抽屉里
        {
            Debug.Log(name);
            Debug.Log(poolDic.Count);
            Obj = poolDic[name].Pop();//拉出对象出来
            if (Obj != null)
            {
                 Obj.SetActive(true);//激活对象
                 Obj.transform.position = Position.position;
            }
           
           
        }
        else//没有抽屉或者抽屉里没对象则创建对象
        {
            Obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            Obj.transform.position = Position.position;
        }
        Obj.name = name;

        return Obj;
    }
    //放入对象到抽屉里
    public void putObj(GameObject obj)
    {
        obj.SetActive(false);
        //抽屉不存在
        Debug.Log(obj.name);
        if (!poolDic.ContainsKey(obj.name))
        {
            //创建抽屉
            Debug.Log("创建成功");
            poolDic.Add(obj.name, new Stack<GameObject>());
        }
        //放入对象
        poolDic[obj.name].Push(obj);
    }
    public void clear()
    {
        poolDic.Clear();//清除对象
    }
}
