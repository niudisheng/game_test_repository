using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject endPanel;
    public bag playerBag;
    private void Start()
    {
        soundManager.Instance.playMusic("theme");
    }
    public void PlayGame()
    {

        endPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void clear()
    {
        playerBag.items.Clear();
    }
}
