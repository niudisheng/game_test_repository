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
            // ���¼�ʱ��ʱ��
            currentTime += Time.deltaTime;

            // ����ʱ���Ƿ�ﵽ����ʱ��
            if (currentTime >= timerDuration)
            {
                // ��ʱ���ﵽ����ʱ�䣬ִ����Ӧ����
                TimerCompleted();
                isTimerRunning=false;
            }
        }
        
    }

    

    private void TimerCompleted()
    {
        // ��ʱ����ɺ�Ĳ���
        Debug.Log("��ʱ�����");
        soundManager.Instance.playMusic("theme");
    }
}
