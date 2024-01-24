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
     
       

        //背景移动
        if (transform.position.x <= 57-weiyi)
            transform.position = startPosition;
        transform.Translate(-speed, 0, 0);
    }
}
