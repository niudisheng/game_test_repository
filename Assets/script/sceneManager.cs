using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : baseNomonoManager<sceneManager>
{
    string prefabDirectory= "../prefab/soundManager";
    GameObject soundManager_prefab= Resources.Load<GameObject>(instance.prefabDirectory);
    //转换关卡的函数
    public void changeScene(int sceneNum)
    {   

        soundManager.stopMusic();
        GameObject soundManager_instance = GameObject.Instantiate(soundManager_prefab);
        
        SceneManager.LoadScene(sceneNum,LoadSceneMode.Single);
    }
    public void reTry()//重开
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
    

}
