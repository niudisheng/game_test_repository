using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        sceneManager.Instance.changeScene(4);
    }
    public void reTry()
    {
        sceneManager.Instance.reTry();
    }
}
