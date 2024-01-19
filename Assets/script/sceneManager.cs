using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : baseNomonoManager<sceneManager>
{
    //ת���ؿ��ĺ���
    public void changeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void reTry()//�ؿ�
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void addScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(scene);
    }
    public void changeScene(string sceneName)
    {       
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);        
    }
    
}
