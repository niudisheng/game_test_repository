using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;
    private AudioSource audioManager;
    private AudioClip jumpSound;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }
    private void Start()
    {
        audioManager = GetComponent<AudioSource>();
        //�������Resources���ظ���AudioClip
        jumpSound = Resources.Load<AudioClip>("sound/Saint5");
    }
    //������д��ͬ��Ч�Ĳ�ͬ����
   static public void jumpingSound()
    {
       //Instance.audioManager.PlayOneShot(Instance.jumpSound);
    }
}
