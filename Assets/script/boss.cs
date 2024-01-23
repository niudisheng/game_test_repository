using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class boss : MonoBehaviour
{
    public GameObject Obstacle;
    public float refreshTime;//间隔多久刷新障碍物
    private float startRefreashTime;
    private int randomNum;
    public obstacle obstacleReBound;
    public MagicBall MagicBall;
    public point point;
    public float changePositionTime;
    private int randomNumForPosit;
    private float StartChangePositionTime;
    public float moveSpeed;
    public Transform[] position = new Transform[4];
    private Vector2 nowPosition;
    public float[] positionLittleChange = new float[2];
    //private int lastRandomNum;
    // Start is called before the first frame update
    void Start()
    {
        startRefreashTime = refreshTime;
        StartChangePositionTime = changePositionTime;
    } 

    // Update is called once per frame
    void Update()
    {
        ObstacRefresh();
        ChangePositionTime();
    }
    void ChangePositionTime()
    {
        changePositionTime -= Time.deltaTime;
        if (changePositionTime <= 0)
        {
            randomNumForPosit = Random.Range(1, 4);
            print(randomNumForPosit);
            if (randomNumForPosit == 1)
            {
                nowPosition = new Vector2(transform.position.x, position[randomNumForPosit - 1].position.y - positionLittleChange[0]);
            }
            if (randomNumForPosit == 2)
            {
                nowPosition = new Vector2(transform.position.x, position[randomNumForPosit - 1].position.y);
            }
            if (randomNumForPosit == 3)
            {
                nowPosition = new Vector2(transform.position.x, position[randomNumForPosit - 1].position.y + positionLittleChange[1]);
            }
            changePositionTime = StartChangePositionTime;
        }
        transform.position = Vector3.MoveTowards(transform.position, nowPosition, moveSpeed);
    }
    void ObstacRefresh()
    {
        randomNum = Random.Range(1, 8);//生成1，2，3，4，5，6，7
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0 )
        {
            if(randomNum<=2&&randomNum>=1)//第一行
            {
                poolMgr.Instance.getObj("obstacle", position[0]);
            }
            
            if (randomNum <= 5 && randomNum >= 3)//第二行
            {
                poolMgr.Instance.getObj("obstacle", position[1]);
            }
             if (randomNum >= 6 && randomNum <= 7)//第三行  
            {
                poolMgr.Instance.getObj("obstacle", position[2]);
            }
            refreshTime = startRefreashTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            point.TimePoint +=obstacleReBound.damageToBoss;
        }
        if (collision.gameObject.CompareTag("MagicBall"))
        {
            point.TimePoint +=MagicBall.BallDamage;
        }
    }
}
