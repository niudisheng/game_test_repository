using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    // Start is called before the first frame update
    public string BGM;
    void Start()
    {
        soundManager.Instance.playMusic(BGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
