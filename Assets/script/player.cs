using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour
{
    private Animator aniPlayer;
    private Rigidbody2D RigPlayer;
    public float speed;
    private float InputX;
    private float InputY;
    private float stopInputX;
    private float stopInputY;
    // Start is called before the first frame update
    void Start()
    {
        RigPlayer = GetComponent<Rigidbody2D>();
        aniPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }
    void playerMove()
    {
        
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");
        //实时获取角色移动的向量
        Vector2 input = new Vector2(InputX, InputY).normalized;//标准化
        RigPlayer.velocity = input*speed;
        //动画后面美术动画出来后再搞
    }
}
