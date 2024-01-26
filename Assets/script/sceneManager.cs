using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : baseNomonoManager<sceneManager>
{
    //string prefabDirectory= "soundManager";
    
    //ת���ؿ��ĺ���
    public void changeScene(int sceneNum)
    {
        soundManager.stopMusic();
        SceneManager.LoadScene(sceneNum,LoadSceneMode.Single);
    }
    public void reTry()//�ؿ�
    {
        soundManager.stopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
