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
        endPanel.fillAmount = 1;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
        endPanel.fillAmount += 1f / endTime * Time.deltaTime;
>>>>>>> parent of ed29f3fb (1)
>>>>>>> parent of fb5454e9 (1)
=======
>>>>>>> parent of b9147ae6 (1)
=======
>>>>>>> parent of b9147ae6 (1)
        if (endPanel.fillAmount >= 1 )
        {
            sceneManager.Instance.changeScene(sceneNum);
        }
        
    }
}
