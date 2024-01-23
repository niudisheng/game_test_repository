using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUI : MonoBehaviour
{
    public GameObject wallTwo;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Guide();
    }

    private void Guide()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Time.timeScale = 1f;
            Destroy(wallTwo);
            Player.GetComponent<PlayerIncombat>().MoveUP();
            Player.GetComponent<PlayerIncombat>().FinishGuide();
            gameObject.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 1f;
            Destroy(wallTwo);
            Player.GetComponent<PlayerIncombat>().MoveDown();
            Player.GetComponent<PlayerIncombat>().FinishGuide();
            gameObject.SetActive(false);
        }
    }
}
