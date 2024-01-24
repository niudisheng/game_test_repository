using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountTime : MonoBehaviour
{
    public float playTime;
    public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;
        if (playTime < 0 )
        {
            sceneManager.Instance.changeScene(sceneNum);
        }
    }
}
