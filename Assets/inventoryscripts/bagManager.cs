using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class bagManager : MonoBehaviour
{
    public GameObject bagPenel;
    public player player;//£¡£¡£¡ÍÏÈë
    public static bagManager instance;
<<<<<<< HEAD
    public bag playerBag;
    private void Start()
    {
        //°ÑµÀ¾ßº¯Êı³õÊ¼»¯µ½ÊÂ¼şÖĞĞÄ
        eventsystem.Instance.setUp("daojuming", text);//´Ëstring±äÁ¿ºÍµÀ¾ßÃû×ÖÓ¦¸ÃÏàÍ¬
        //Ê¹³¡¾°Ë¢ĞÂºóÔÚÇ°Ò»¸ö³¡¾°ÒÑ¾­»ñÈ¡µÄµÀ¾ßÉúĞ§
        for(int i=0;i<instance.playerBag.items.Count;i++)
        {
            if (instance.playerBag.items[i].isGet)
            {
                eventsystem.Instance.EventInvoke(instance.playerBag.items[i].name);
            }
        }
    }
=======
>>>>>>> ç¨‹åºé»‘çŒ«çš„æ³ªç—£
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(this);
        }
        instance = this;
    }
     void OnEnable()//¸ù¾İ
    {
        
    }
    static void refreshItem()
    {
        //ÏÈÉ¾³ı
        for(int i=0;i<instance.bagPenel.transform.childCount;i++)
        {
            if (instance.bagPenel.transform.childCount == 0)
                break;
            Destroy(instance.bagPenel.transform.GetChild(i).gameObject);
        }
<<<<<<< HEAD
        //ºó¸üĞÂ
        for(int i=0;i<instance.playerBag.items.Count;i++)
        {
            //¸üĞÂÃ¿¸öbagÀïµÀ¾ßµÄÊı¾İµ½UIÀï£¨ÊıÄ¿£¬ÃèÊö£¬£©
        }
    }
    //ÏÂÃæĞ´¸÷¸öµÀ¾ß¶ÔÍæ¼ÒµÄÓ°ÏìµÄº¯Êı
    void text()
    {
        print("text");
    }
=======
        //
    }


>>>>>>> ç¨‹åºé»‘çŒ«çš„æ³ªç—£
}
