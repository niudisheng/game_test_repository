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
    [Header("文件管理与播放器")]
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void playMusic(string name)
    {
        Debug.Log("play");
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
    public void playSFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
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
    static public void stopMusic()
    {
        Instance.musicSource.Stop();
    }
}
