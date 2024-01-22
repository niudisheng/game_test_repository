using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RoleManager : MonoBehaviour
{
    public static RoleManager instance;
    public Text RoleDespri;
    private Role thisRole;
    public Role role1;
    public Role role2;
    public GameObject RemindPanel;
    public GameObject ChooseItem;
    public bag playerBag;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);//��ֹ����������
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�����ı����Լ�����Role�����������Ϊ�˺���ȷ����׼��
   static public void ReflashGetRole(Role role)
    {
        instance.thisRole = role;//�������е�role
        //����text�ı�
        instance.RoleDespri.text = role.RoleSkill.ToString();
    }

    //����ɫ���Ϊ�����ã���ѡ��ɫ����ʱ����
    static public void CancelUse()
    {
        instance.role1.RokeIsUse = false;
        instance.role2.RokeIsUse = false;
    }
    public void isChooseOne()//ȷ��
    {
        if (thisRole)
        {
            thisRole.RokeIsUse = true;
        }
        if (!role1.RokeIsUse && !role2.RokeIsUse)//û��ʹ�ý�ɫ
        {
            //��������
            RemindPanel.SetActive(true);
        }
        else if(role1.RokeIsUse|| role2.RokeIsUse)//ѡ��һ����ɫ��
        {
            //����ѡװ���Ľ���
            this.gameObject.SetActive(false);
            ChooseItem.SetActive(true);
        }
    }
    public void clearBag()
    {
        if (playerBag.items.Count >= 2)
        {
            playerBag.items[0].isGet = false;
            playerBag.items[1].isGet = false;
        }
        if (playerBag.items.Count ==1)
        {
            playerBag.items[0].isGet = false;
        }
        playerBag.items.Clear();
    }
}