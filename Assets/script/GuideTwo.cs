using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTwo : MonoBehaviour
{
    private BoxCollider2D secondWall;
    public GameObject GuideUI;
    // Start is called before the first frame update
    void Start()
    {
        secondWall = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            GuideUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
