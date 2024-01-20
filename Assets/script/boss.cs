using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject Obstacle;
    public float refreshTime;//������ˢ���ϰ���
    private float startRefreashTime;
    private int randomNum;
    public int BossHealth;//boss����
    public obstacle obstacleReBound;
    public MagicBall MagicBall;
    //private int lastRandomNum;
    // Start is called before the first frame update
    void Start()
    {
        startRefreashTime = refreshTime;
    } 

    // Update is called once per frame
    void Update()
    {
        ObstacRefresh();
        print(randomNum);
        if (BossHealth < 0)
        {
            print("boss����");
        }
        
    }
    void ObstacRefresh()
    {
        randomNum = Random.Range(1, 8);//����1��2��3��4��5��6��7
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0 )
        {
            if(randomNum<=2&&randomNum>=1)//��һ��
            {
               Instantiate(Obstacle, transform.GetChild(0).transform.position, Quaternion.identity);
            }
            
            if (randomNum <= 5 && randomNum >= 3)//�ڶ���
            {
               Instantiate(Obstacle, transform.GetChild(1).transform.position, Quaternion.identity);
            }
             if (randomNum >= 6 && randomNum <= 7)//������  
            {
                Instantiate(Obstacle, transform.GetChild(2).transform.position, Quaternion.identity);
            }
            refreshTime = startRefreashTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            BossHealth -= obstacleReBound.damageToBoss;
        }
        if (collision.gameObject.CompareTag("magicBall"))
        {
            BossHealth -= MagicBall.BallDamage;
        }
    }
}
