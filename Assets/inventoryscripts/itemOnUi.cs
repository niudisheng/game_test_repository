using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnUi : MonoBehaviour
{
    public item ThisItem;//外部拖入
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickOnItem()
    {
        //把这个Item传给bagNamager;
        bagManager.getItem(ThisItem);
    }
}
