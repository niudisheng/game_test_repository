using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public PlayerIncombat PlayerIncombat;//����������
    public static bagManager instance;
    public bag playerBag;
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
     void OnEnable()//���ݵ���boolֵ�ж��Ƿ�Ҫ�����¼����Ķ�Ӧ���ߵĺ���
    {

    }  
public static void refreshItem()
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

}
