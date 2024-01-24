using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public float startTime;
    public Image startPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startPanel.fillAmount -= 1f / startTime * Time.deltaTime;
    }
}
