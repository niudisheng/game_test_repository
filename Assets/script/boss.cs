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
    public obstacle obstacleReBound;
    public MagicBall MagicBall;
    public point point;
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
    }
    void ObstacRefresh()
    {
        randomNum = Random.Range(1, 8);//����1��2��3��4��5��6��7
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0 )
        {
            if(randomNum<=2&&randomNum>=1)//��һ��
            {
                poolMgr.Instance.getObj("obstacle", transform.GetChild(0).transform);
            }
            
            if (randomNum <= 5 && randomNum >= 3)//�ڶ���
            {
                poolMgr.Instance.getObj("obstacle", transform.GetChild(1).transform);
            }
             if (randomNum >= 6 && randomNum <= 7)//������  
            {
                poolMgr.Instance.getObj("obstacle", transform.GetChild(2).transform);
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
