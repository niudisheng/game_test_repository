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
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);//防止有两个单例
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
    //更新文本的以及更新Role到这个单例中为了后面确定做准备
   static public void ReflashGetRole(Role role)
    {
        instance.thisRole = role;//更新已有的role
        //更新text文本
        instance.RoleDespri.text = role.RoleSkill.ToString();
    }

    //将角色设计为都不用，打开选角色界面时调用
    public static void CancelUse()
    {
        instance.role1.RokeIsUse = false;
        instance.role2.RokeIsUse = false;
    }
    public void isChooseOne()//确定
    {
        if (thisRole)
        {
            thisRole.RokeIsUse = true;
        }
        if (!role1.RokeIsUse && !role2.RokeIsUse)//没有使用角色
        {
            //生成提醒
            RemindPanel.SetActive(true);
        }
        else if(role1.RokeIsUse|| role2.RokeIsUse)//选择一个角色了
        {
            //生成选装备的界面
            this.gameObject.SetActive(false);
            ChooseItem.SetActive(true);
        }
    }
}
