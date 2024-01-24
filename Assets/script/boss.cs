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
    public Transform[] position = new Transform[3];
    private Vector2 nowPosition;
    public float[] positionLittleChange = new float[3];
    public bool isChangeFlashTime;
    public bool changePosi;   
    public bool isChangeObstacleSpeed;
    public float leftSpeed;
    public Animator bossAni;
    public bool isLastOne;
    public bool isLastTwe;
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
        IsChangeFlashTime();
        IsChangeObstacleSpeed();
       
    }
    void IsChangeObstacleSpeed()
    {
        if (isChangeObstacleSpeed && leftSpeed <= 17)
        {
            leftSpeed += (Time.deltaTime * 0.03f);
        }

    }
   void IsChangeFlashTime()
    {
        if (isChangeFlashTime&&startRefreashTime>=0.6)
        {
            startRefreashTime -= (Time.deltaTime * 0.005f);
        }
    }
    void ChangePositionTime()
    {
        changePositionTime -= Time.deltaTime;
        if (changePositionTime <= 0 && changePosi)
        {
            randomNumForPosit = Random.Range(1, 4);
            print(randomNumForPosit);
            if (randomNumForPosit == 1)
            {
                nowPosition = new Vector2(transform.position.x , position[randomNumForPosit - 1].position.y - positionLittleChange[0]);
                if (!isLastOne)
                {
                  bossAni.SetTrigger("isUp 0");
                }
                isLastTwe = false;
                isLastOne = true;
            }
            if (randomNumForPosit == 2)
            {
                nowPosition = new Vector2(transform.position.x , position[randomNumForPosit - 1].position.y);
              
            
                if(!isLastTwe)
                {
                    if (isLastOne)
                    {
                        bossAni.SetTrigger("isDown 0");
                    }
                    else
                    {
                        bossAni.SetTrigger("isUp 0");
                    }
                }
              isLastTwe = true;
            }
            if (randomNumForPosit == 3)
            {
                nowPosition = new Vector2(transform.position.x, position[randomNumForPosit - 1].position.y + positionLittleChange[1]);
                if (isLastOne || isLastTwe)
                {
                    bossAni.SetTrigger("isDown 0");
                }
                isLastOne = false;
                isLastTwe = false;
            }
            changePositionTime = StartChangePositionTime;
        }
        if (Time.timeScale != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(this.transform.position.x, nowPosition.y), moveSpeed);
        }
       
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
