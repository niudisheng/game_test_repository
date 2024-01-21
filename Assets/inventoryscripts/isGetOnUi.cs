using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isGetOnUi : MonoBehaviour
{
    public Image image;//นด
    public item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.enabled = item.isGet;
    }
}
