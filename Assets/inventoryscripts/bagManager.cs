using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public player player;//����������
    public static bagManager instance;
    public bag playerBag;
    private void Start()
    {
        //�ѵ��ߺ�����ʼ�����¼�����
        eventsystem.Instance.setUpOrAdd("daojuming", text);//��string�����͵�������Ӧ����ͬ
        //ʹ����ˢ�º���ǰһ�������Ѿ���ȡ�ĵ�����Ч
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
     void OnEnable()//����
    {
        
    }
    static void refreshItem()
    {
        //��ɾ��
        for(int i=0;i<instance.bagPenel.transform.childCount;i++)
        {
            if (instance.bagPenel.transform.childCount == 0)
                break;
            Destroy(instance.bagPenel.transform.GetChild(i).gameObject);
        }
        //�����
        for(int i=0;i<instance.playerBag.items.Count;i++)
        {
            //����ÿ��bag����ߵ����ݵ�UI���Ŀ����������
        }
    }
    //����д�������߶���ҵ�Ӱ��ĺ���
    void text()
    {
        print("text");
    }
}