using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float leftSpeed;
    public float rightSpeed;
    public bool isReBound;
    public float damageToBoss;
    private SpriteRenderer ObstacleRen;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        isReBound = false;
        rb = GetComponent<Rigidbody2D>();
        ObstacleRen = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!isReBound)
        {
            rb.velocity = new Vector2(-leftSpeed, rb.velocity.y);//向左移动
        }
       else
        {
            rb.velocity = new Vector2(rightSpeed, rb.velocity.y);//向左移动
        }
        if (rb.velocity.x > 0)
        {
            ObstacleRen.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleRemover")|| collision.gameObject.CompareTag("boss"))//在摄像机外去除障碍
        {
            isReBound = false;
            ObstacleRen.flipX = false;
            poolMgr.Instance.putObj(this.gameObject);

        }
    }
}
