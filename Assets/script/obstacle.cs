using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);//向左移动
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleRemover"))//在摄像机外去除障碍
        {
            Destroy(this.gameObject);
        }
    }
}
