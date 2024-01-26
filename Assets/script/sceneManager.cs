using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : baseNomonoManager<sceneManager>
{
    //string prefabDirectory= "soundManager";
    
    //转换关卡的函数
    public void changeScene(int sceneNum)
    {
        soundManager.stopMusic();
        SceneManager.LoadScene(sceneNum,LoadSceneMode.Single);
    }
    public void reTry()//重开
    {
        soundManager.stopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
