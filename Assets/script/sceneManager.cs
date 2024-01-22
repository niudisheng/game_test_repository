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
        //GameObject soundManager_prefab = Resources.Load<GameObject>(instance.prefabDirectory);
        //GameObject soundManager_instance = Object.Instantiate(soundManager_prefab);
        //GameObject instantiatedPrefab = Object.Instantiate(soundManager_instance);
        SceneManager.LoadScene(sceneNum,LoadSceneMode.Single);
    }
    public void reTry()//重开
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
    

}
