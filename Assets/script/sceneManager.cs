using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : baseNomonoManager<sceneManager>
{
    string prefabDirectory= "../prefab/soundManager";
    GameObject soundManager_prefab= Resources.Load<GameObject>(instance.prefabDirectory);
    //ת���ؿ��ĺ���
    public void changeScene(int sceneNum)
    {   

        soundManager.stopMusic();
        GameObject soundManager_instance = GameObject.Instantiate(soundManager_prefab);
        
        SceneManager.LoadScene(sceneNum,LoadSceneMode.Single);
    }
    public void reTry()//�ؿ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
    

}
