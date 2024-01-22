using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bag playerBag;
    private void Start()
    {
        soundManager.Instance.playMusic("theme");
    }
    public void PlayGame()
    {
        sceneManager.Instance.changeScene(1);
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
