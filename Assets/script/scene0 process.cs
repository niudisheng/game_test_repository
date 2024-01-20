using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scene0process : MonoBehaviour
{
    public TextAsset textFile;
    bool is_talk = false;
    private float timerDuration = 2f; // ��ʱ������ʱ�䣨�룩
    private float currentTime = 0f; // ��ǰ��ʱ��ʱ��
    private bool isTimerRunning = false; // ��־λ��ָʾ��ʱ���Ƿ���������

    private void Start()
    {
        StartTimer();
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
        // ��ʱ����ɺ�Ĳ���
        Debug.Log("��ʱ�����");
        isTimerRunning = false;
        DialogSystem.awake_talk_ui(textFile);
        if (!is_talk)
        {
            
            DialogSystem.awake_talk_ui(textFile);
            is_talk = true;
        }
    }
}

