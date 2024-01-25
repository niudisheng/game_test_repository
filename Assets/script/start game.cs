using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class startgame : MonoBehaviour
{   
    public GameObject button1;
    public GameObject button2;
    public GameObject title;
    Animator ani;
    bool isTimerRunning;
    float currentTime;
    float timerDuration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        title.SetActive(true);
        ani = GetComponent<Animator>();
        ani.speed = 0f;
        soundManager.Instance.playSFX("turn on");
        StartTimer();
        
    }
    private void StartTimer()
    {
        currentTime = 0f;
        isTimerRunning = true;
    }
    private void Update()
    {
        if (isTimerRunning)
        {
            // 更新计时器时间
            currentTime += Time.deltaTime;

            // 检查计时器是否达到持续时间
            if (currentTime >= timerDuration)
            {
                // 计时器达到持续时间，执行相应操作
                TimerCompleted();
                isTimerRunning=false;
            }
        }
        
    }

    

    private void TimerCompleted()
    {
        // 计时器完成后的操作
        Debug.Log("计时器完成");
        soundManager.Instance.playMusic("theme");
    }
}
