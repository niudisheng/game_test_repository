using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPointText : MonoBehaviour
{
    public Text PointText;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnEnable()
    {
        this.GetComponent<Text>().text = PointText.text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
