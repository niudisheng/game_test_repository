using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public GameObject clearOutTime;
    public PlayerIncombat PlayerIncombat;//����������
    public static bagManager instance;
    public bag playerBag;
    public Text ItemCd;//����������Ϣ
    public Text describe;
    public Text itemName;
    public Text RollTime;
    public item thisItem;
    public GameObject reComfine;
    public GameObject[] comfine = new GameObject[2];
    private void Start()
    {
       
       
    }
    private void Update()
    {
        if (playerBag.items.Count >= 2)
        {
            comfine[0].SetActive(false);
            comfine[1].SetActive(true);
        }
        else
        {
            comfine[0].SetActive(true);
            comfine[1].SetActive(false);
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
     void OnEnable()//���ݵ���boolֵ�ж��Ƿ�Ҫ�����¼����Ķ�Ӧ���ߵĺ���
    {

    }  
    public void clearAllItemOnBag()//�������������е���
    {
        for (int i = 0; i < playerBag.items.Count; i++)
        {
            playerBag.items[i].isGet = false;
        }
        playerBag.items.Clear();
    }
    public  void refreshItemOnBag()//�ⲿʹ�õ��ߣ���ת��bag�ͬʱ��isGet
    {
        if (playerBag.items.Count <2)
        {
            playerBag.items.Add(thisItem);
            thisItem.isGet = true;
            KeepData.SelectEquipment(thisItem);
        }
        else
        {
            clearOutTime.SetActive(true);
        }
        
    }
    public static void getItem(item thisItem)
    {
        instance.thisItem = thisItem;
          //������Ϣ����Ϣ��
        instance.ItemCd.text =instance.thisItem.Cd.ToString();
        instance.describe.text = instance.thisItem.describe.ToString();
        instance.itemName.text = instance.thisItem.Name.ToString();
        instance.RollTime.text = instance.thisItem.RollTime.ToString();
    }
    public static void IsChooseTweItem()
    {
        if (instance.playerBag.items.Count < 2)
        {
            instance.reComfine.SetActive(true);
        }
        else
        {
            instance.gameObject.SetActive(false);
            sceneManager.Instance.changeScene(5);
        }
    }
    public void ToEndlessScene()
    {
        sceneManager.Instance.changeScene(6);
    }
}
