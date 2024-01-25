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

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        endPanel.fillAmount = 1;
=======
        endPanel.fillAmount += 1f / endTime * Time.deltaTime;
<<<<<<< HEAD
>>>>>>> parent of ed29f3fb (1)
=======
>>>>>>> parent of ed29f3fb (1)
        if (endPanel.fillAmount >= 1 )
        {
            sceneManager.Instance.changeScene(sceneNum);
        }
        
    }
}
