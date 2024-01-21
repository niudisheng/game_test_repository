using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;
    private AudioSource audioManager;
    private AudioClip jumpSound;
    [Header("�ļ������벥����")]
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void playSound(string name)
    {
        Sound s = Array.Find(musicSound,x=>x.name==name);
        if (s == null)
        {
            Debug.Log("Not found");
        }
        else
        {
            musicSource.clip=s.clip;
            musicSource.Play();
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        playSound("theme");
        audioManager = GetComponent<AudioSource>();
        //�������Resources���ظ���AudioClip
        jumpSound = Resources.Load<AudioClip>("sound/Saint5");
    }
    //������д��ͬ��Ч�Ĳ�ͬ����
    static public void jumpingSound()
    {
        Instance.audioManager.PlayOneShot(Instance.jumpSound);
    }
    static public void stopMusic()
    {
        Instance.musicSource.Stop();
    }
}
