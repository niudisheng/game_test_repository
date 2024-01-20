using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scene0process : MonoBehaviour
{
    public TextAsset textFile;
    bool is_talk = false;
    private float timerDuration = 2f; // 计时器持续时间（秒）
    private float currentTime = 0f; // 当前计时器时间
    private bool isTimerRunning = false; // 标志位，指示计时器是否在运行中

    private void Start()
    {
        StartTimer();
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
            }
        }
        if (is_talk)
        {
            is_talk = DialogSystem.blit_text();
        }
    }

    private void StartTimer()
    {
        currentTime = 0f;
        isTimerRunning = true;
    }

    private void TimerCompleted()
    {
        // 计时器完成后的操作
        Debug.Log("计时器完成");
        isTimerRunning = false;
        DialogSystem.awake_talk_ui(textFile);
        if (!is_talk)
        {
            
            DialogSystem.awake_talk_ui(textFile);
            is_talk = true;
        }
    }
}

