using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnUi : MonoBehaviour
{
    public item ThisItem;//�ⲿ����
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
        //�����Item����bagNamager;
        bagManager.getItem(ThisItem);
    }
}
