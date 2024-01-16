using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemOnworld : MonoBehaviour
{
    public bag playerBag;
    public item playerItem;//!!!!在外部拖入
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
            AddItem();
            //调用道具拥有的作用函数
            eventsystem.Instance.EventInvoke(playerItem.name);
            playerItem.isGet = true;
            Destroy(this.gameObject);
        }
    }
   void AddItem()
    {    
        //看是否涉及多个道具
            //判断道具是否已经获取过一次？
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
