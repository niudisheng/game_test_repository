using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour,Imysigninterfence
{
    public Sprite closeSprite;//����sprite
    public Sprite openSprite;

    private bool isOpen;//���س������жϱ����Ƿ��
    private SpriteRenderer boxSprite;
    public bag playerBag;
    public item InvincibleItem;//!!!!���ⲿ����
    public item wandItem;
    public item reBoundItem;
    public void interaction()
    {
        if (!playerBag.items.Contains(InvincibleItem))//�޵�
        {
            Debug.Log("�򿪱����ɹ�");
            playerBag.items.Add(InvincibleItem);//��ӵ�����
            InvincibleItem.isGet = true;
            eventsystem.Instance.EventInvoke("Invincible");
            //sceneManager.Instance.nextScene();
            InvincibleItem.numItem++;
            //ItemManager.creatNewItem(thisItem);
        }
        else
        {
            InvincibleItem.numItem++;
            InvincibleItem.isGet = true;
        }
        if (!playerBag.items.Contains(wandItem))//����
        {
            Debug.Log("�򿪱����ɹ�");
            playerBag.items.Add(wandItem);//��ӵ�����
            wandItem.isGet = true;
            eventsystem.Instance.EventInvoke("wand");
            //sceneManager.Instance.nextScene();
            wandItem.numItem++;
            //ItemManager.creatNewItem(thisItem);
        }
        else
        {
            wandItem.numItem++;
            wandItem.isGet = true;
        }
        if (!playerBag.items.Contains(reBoundItem))//����
        {
            Debug.Log("�򿪱����ɹ�");
            playerBag.items.Add(reBoundItem);//��ӵ�����
            reBoundItem.isGet = true;
            eventsystem.Instance.EventInvoke("reBoundItem");
            //sceneManager.Instance.nextScene();
            reBoundItem.numItem++;
            //ItemManager.creatNewItem(thisItem);
        }
        else
        {
            reBoundItem.numItem++;
            reBoundItem.isGet = true;
        }
        bagManager.refreshItem();//��bag������ݸ��µ�UI��
        gameObject.tag = "Untagged";
        isOpen = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        boxSprite = GetComponent<SpriteRenderer>();
        //��¼�Ƿ�򿪿������ļ���
    }
    void OnEnable()    // Update is called once per frame
    {
        //���±���ͼ��״̬
        //boxSprite.sprite = isOpen ? openSprite : closeSprite;
        if(isOpen)
        {
            gameObject.tag = "Untagged";
        }
    }
    void Update()
    {
        
    }
}
