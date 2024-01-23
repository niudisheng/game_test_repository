using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideOne : MonoBehaviour
{

    private BoxCollider2D firstWall;
    public GameObject GuideUI;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        firstWall = GetComponent<BoxCollider2D>();
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
            Time.timeScale = 0.3f;
            Destroy(gameObject);
        }
    }
}
