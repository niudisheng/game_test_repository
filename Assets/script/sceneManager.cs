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
    
}
