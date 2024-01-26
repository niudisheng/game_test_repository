using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    public static startmusic Instance;
    // Start is called before the first frame update
    public string BGM;
    string prefabDirectory = "soundManager";
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        
    }
    void Start()
    {
        
        if (soundManager.Instance == null)
        {
            
            GameObject loadedPrefab = Resources.Load<GameObject>(prefabDirectory);
            GameObject instantiatedPrefab = Instantiate(loadedPrefab);
        }
        soundManager.Instance.playMusic(BGM);
    }  
}
