using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject Obstacle;
    public float refreshTime;//间隔多久刷新障碍物
    private float startRefreashTime;
    private int randomNum;
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
        
        
    }
    void ObstacRefresh()
    {
        randomNum = Random.Range(1,4);
        refreshTime -= Time.deltaTime;
        if (refreshTime <= 0 )
        {
            Instantiate(Obstacle, transform.GetChild(randomNum - 1).transform.position, Quaternion.identity);
            refreshTime = startRefreashTime;
        }
    }
}
