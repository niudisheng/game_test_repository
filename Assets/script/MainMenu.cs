using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        soundManager.Instance.playMusic("theme");
    }
    public void PlayGame()
    {
        sceneManager.Instance.changeScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
