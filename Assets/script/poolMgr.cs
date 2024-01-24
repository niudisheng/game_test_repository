using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolMgr: baseNomonoManager<poolMgr>
{
    //�����ֵ����
    public Dictionary<string, Stack<GameObject>> poolDic = new Dictionary<string, Stack<GameObject>>();
    //��ȡ���������ĺ���

    public GameObject getObj(string name,Transform Position)
    {
        GameObject Obj;
        if (poolDic.ContainsKey(name) && poolDic[name].Count > 0)//�ж����ڳ�����
        {
            Debug.Log(name);
            Debug.Log(poolDic.Count);
            Obj = poolDic[name].Pop();//�����������
            if (Obj != null)
            {
                 Obj.SetActive(true);//�������
                 Obj.transform.position = Position.position;
            }
           
           
        }
        else//û�г�����߳�����û�����򴴽�����
        {
            Obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            Obj.transform.position = Position.position;
        }
        Obj.name = name;

        return Obj;
    }
    //������󵽳�����
    public void putObj(GameObject obj)
    {
        obj.SetActive(false);
        //���벻����
        Debug.Log(obj.name);
        if (!poolDic.ContainsKey(obj.name))
        {
            //��������
            Debug.Log("�����ɹ�");
            poolDic.Add(obj.name, new Stack<GameObject>());
        }
        //�������
        poolDic[obj.name].Push(obj);
    }
    public void clear()
    {
        poolDic.Clear();//�������
    }
}
