using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    Animator animator;
    Rigidbody2D rb;
    public float move_speed;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
        if (move_speed == 0)
        { move_speed = 100; }
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        //获取ws或上下的按下情况
        float vertical = Input.GetAxisRaw("Vertical");
        move = new Vector2(horizontal, vertical);
        animator.SetFloat("move_value", 0);
        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))//在不接近于0时设置
        {
            animator.SetFloat("move_value", 1);
        }
        else
        {
            animator.SetFloat("move_value", 0);
        }
        move = new(horizontal,vertical);
        
        move=move*move_speed;
        rb.velocity = move;       
    }
}
