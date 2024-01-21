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
        //根据背包里的item图片更新到UI里
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
                if (playerBag.items[0].Name == "盾牌")
                {
                    eventsystem.Instance.EventInvoke("玩家使用盾牌");
                }
                if (playerBag.items[0].Name == "魔力法杖")
                {
                    eventsystem.Instance.EventInvoke("玩家使用魔力法杖");
                }
                if (playerBag.items[0].Name == "反弹护盾")
                {
                    eventsystem.Instance.EventInvoke("玩家使用反弹护盾");
                }
                if (playerBag.items[0].Name == "不休短刃")
                {
                    eventsystem.Instance.EventInvoke("玩家使用不休短刃");
                }
                if (playerBag.items[0].Name == "终焉圣裁")
                {
                    eventsystem.Instance.EventInvoke("玩家使用终焉圣裁");
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(playerBag.items.Count >= 2)
            {
                if (playerBag.items[1].Name == "盾牌")
                {
                    eventsystem.Instance.EventInvoke("玩家使用盾牌");
                }
                if (playerBag.items[1].Name == "魔力法杖")
                {
                    eventsystem.Instance.EventInvoke("玩家使用魔力法杖");
                }
                if (playerBag.items[1].Name == "反弹护盾")
                {
                    eventsystem.Instance.EventInvoke("玩家使用反弹护盾");
                }
                if (playerBag.items[1].Name == "不休短刃")
                {
                    eventsystem.Instance.EventInvoke("玩家使用不休短刃");
                }
                if (playerBag.items[1].Name == "终焉圣裁")
                {
                    eventsystem.Instance.EventInvoke("玩家使用终焉圣裁");
                }
            }
            
        }
    }
    
    //根据道具

}
