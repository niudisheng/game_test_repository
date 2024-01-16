using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemOnworld : MonoBehaviour
{
    public bag playerBag;
    public item playerItem;//!!!!ÔÚÍâ²¿ÍÏÈë
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
<<<<<<< HEAD
            AddItem();
            //µ÷ÓÃµÀ¾ßÓµÓĞµÄ×÷ÓÃº¯Êı
            eventsystem.Instance.EventInvoke(playerItem.name);
            playerItem.isGet = true;
=======
       
            AddItem();
>>>>>>> ç¨‹åºé»‘çŒ«çš„æ³ªç—£
            Destroy(this.gameObject);
        }
    }
   void AddItem()
    {    
        //¿´ÊÇ·ñÉæ¼°¶à¸öµÀ¾ß
            //ÅĞ¶ÏµÀ¾ßÊÇ·ñÒÑ¾­»ñÈ¡¹ıÒ»´Î£¿
        if(playerBag.items.Contains(playerItem))
        {
            playerItem.numItem++;
        }
        else
        {
            playerBag.items.Add(playerItem);
        }
    }
}
