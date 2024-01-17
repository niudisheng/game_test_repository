using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class sign : MonoBehaviour
{
    public SpriteRenderer signSpriteRen;
    private bool isSignActive;
    private Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        isSignActive = false;
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        signSpriteRen.enabled = isSignActive;
        //调整标识方向用
        //if (playerTrans.position.x >= 0)
        //{
        //    signSpriteRen.flipX = false;
        //}
        //else
        //{
        //    signSpriteRen.flipX = true;
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inteNpc") || collision.gameObject.CompareTag("inteBox"))
        {
            isSignActive = true;
            Debug.Log("stay");
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
                isSignActive = false;
                collision.gameObject.GetComponent<Imysigninterfence>().interaction();
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inteNpc") || collision.gameObject.CompareTag("inteBox"))
        {
            isSignActive = false;
        }
    }
}
