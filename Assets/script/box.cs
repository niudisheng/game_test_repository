using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour,Imysigninterfence
{
    public Sprite closeSprite;
    public Sprite openSprite;
    private bool isOpen;
    public void interaction()
    {
        print("box");
        gameObject.tag = "Untagged";
        isOpen = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()    // Update is called once per frame
    {

    }
    void Update()
    {
        
    }
}
