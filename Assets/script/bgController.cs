using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public GameObject StopMenu;
    public float weiyi;
    public float speed;
    private Vector3 startPosition;
    private bool isOpen;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        print(isOpen);
        
        //暂停界面的控制
        if (Player.GetComponent<PlayerIncombat>().finishGuide == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isOpen = !isOpen;
                if (isOpen)
                {
                    StopMenu.SetActive(isOpen);
                    Time.timeScale = 0;
                }
                else
                {
                    StopMenu.SetActive(isOpen);
                    Time.timeScale = 1;
                }

            }
            if (StopMenu.activeSelf != isOpen)
            {
                isOpen = !isOpen;
                Time.timeScale = 1;
            }
        }
        
        



        //背景移动
        if (Time.timeScale != 0) 
        {
            if (transform.position.x <= startPosition.x - weiyi)
                transform.position = startPosition;
            if (Time.timeScale == 1)
            {
                transform.Translate(-speed, 0, 0);
            }
            if (Time.timeScale == 0.3f)
            {
                transform.Translate(-speed*0.3f, 0, 0);
            }

        }
        
    }
}
