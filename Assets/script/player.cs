using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    Animator animator;
    Rigidbody2D rb;
    public float move_speed;
    public GameObject sign;
    private Vector2 move;
    private Vector3 scale1;
    private Vector3 scale2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
        if (move_speed == 0)
        { move_speed = 100; }
        rb = GetComponent<Rigidbody2D>();
        scale1 = transform.localScale;
        scale2 = sign.transform.localScale;
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


        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (rb.velocity.x > 0.1f)
            {
                transform.localScale = scale1;
                sign.transform.localScale = scale2;

            }

            if (rb.velocity.x < -0.1f)
            {
                transform.localScale = new Vector3(-scale1.x,scale1.y,scale1.z);
                sign.transform.localScale = new Vector3(-scale2.x,scale2.y,scale2.z);

            }
        }
    }
}
