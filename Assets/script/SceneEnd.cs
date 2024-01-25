using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneEnd : MonoBehaviour
{
    public float endTime;
    public int sceneNum;
    public Image endPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        endPanel.fillAmount += 1f / endTime * Time.deltaTime;

        if (endPanel.fillAmount >= 1 )
        {
            sceneManager.Instance.changeScene(sceneNum);
        }
        
    }
}
