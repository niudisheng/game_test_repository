using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagnamagerInBattleScene : MonoBehaviour
{
    public static BagnamagerInBattleScene Instance;
    public bag playerBag;
    public Image[] Item = new Image[2];
    public GameObject[] ItemsImage = new GameObject[2];
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //���ݱ������itemͼƬ���µ�UI��
        for (int i = 0; i < 2; i++) 
        {
            if (i < playerBag.items.Count)
            {
                Item[i].sprite = playerBag.items[i].ItemSprite;
                
            }
            else
            {
                ItemsImage[i].SetActive(false);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(playerBag.items.Count >= 1)
            {
                if (playerBag.items[0].Name == "����")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�ö���");
                }
                if (playerBag.items[0].Name == "ħ������")
                {
                    eventsystem.Instance.EventInvoke("���ʹ��ħ������");
                }
                if (playerBag.items[0].Name == "��������")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�÷�������");
                }
                if (playerBag.items[0].Name == "���ݶ���")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�ò��ݶ���");
                }
                if (playerBag.items[0].Name == "����ʥ��")
                {
                    eventsystem.Instance.EventInvoke("���ʹ������ʥ��");
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(playerBag.items.Count >= 2)
            {
                if (playerBag.items[1].Name == "����")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�ö���");
                }
                if (playerBag.items[1].Name == "ħ������")
                {
                    eventsystem.Instance.EventInvoke("���ʹ��ħ������");
                }
                if (playerBag.items[1].Name == "��������")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�÷�������");
                }
                if (playerBag.items[1].Name == "���ݶ���")
                {
                    eventsystem.Instance.EventInvoke("���ʹ�ò��ݶ���");
                }
                if (playerBag.items[1].Name == "����ʥ��")
                {
                    eventsystem.Instance.EventInvoke("���ʹ������ʥ��");
                }
            }
            
        }
    }
    
    //���ݵ���

}
