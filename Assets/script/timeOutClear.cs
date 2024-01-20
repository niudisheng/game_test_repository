using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeOutClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine("clear");
    }
    IEnumerator clear()
    {
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
