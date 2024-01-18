using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class sign : MonoBehaviour
{
    public SpriteRenderer signSpriteRen;
    private bool isSignActive;
    private Transform playerTrans;
    Collider2D collision_player;
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
        if (isSignActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
                isSignActive = false;
                collision_player.gameObject.GetComponent<Imysigninterfence>().interaction();
            }
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision_player = collision;
        if (collision.gameObject.CompareTag("inteNpc") || collision.gameObject.CompareTag("inteBox"))
        {
            isSignActive = true;
            Debug.Log("enter");
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("inteNpc") || collision.gameObject.CompareTag("inteBox"))
    //    {
    //        isSignActive = true;
    //        Debug.Log("stay");            
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inteNpc") || collision.gameObject.CompareTag("inteBox"))
        {
            isSignActive = false;
        }
    }
}
