using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepData : MonoBehaviour
{
    public int equipmentsNum;
    public static item[] equipped;
    // Start is called before the first frame update
    void Start()
    {
        equipped = new item[equipmentsNum];
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SelectEquipment(item equipment)
    {
        for (int i = 0; i < equipped.Length; i++)
        {
            if (equipped[i] == null)
            {
                equipped[i] = equipment;
                Debug.Log(equipped[i]);
                return;
            }
        }
        
    }
}
