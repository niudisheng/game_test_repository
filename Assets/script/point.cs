using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{
    public GameObject player;
    public boss boss;
    public Text PointText;
    public float TimePoint;
    // Start is called before the first frame update
    void Start()
    {
        TimePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            TimePoint +=(Time.deltaTime)*3f;
        PointText.text = ((int)TimePoint).ToString();
        }
        
    }
}
