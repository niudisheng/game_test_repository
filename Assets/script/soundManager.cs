using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;
    private AudioSource audioManager;
    private AudioClip jumpSound;

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
    }
    private void Start()
    {
        audioManager = GetComponent<AudioSource>();
        //在下面从Resources加载各种AudioClip
        jumpSound = Resources.Load<AudioClip>("sound/Saint5");
    }
    //在下面写不同音效的不同函数
    static public void jumpingSound()
    {
        Instance.audioManager.PlayOneShot(Instance.jumpSound);
    }
}
