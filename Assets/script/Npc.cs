using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, Imysigninterfence
{
    public TextAsset textFile;
    bool is_talk=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_talk)
        {
            is_talk=DialogSystem.blit_text();
        }
    }

    public void interaction()
    {
        if (!is_talk) 
        { 
        print("Npc");
        DialogSystem.awake_talk_ui(textFile);
        is_talk = true;
        }
        
        
    }
}
