using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class HarmfulItems : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    { 
        //��ⴥ��
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerIncombat>().TakeDamage(damage);//�Խ�ɫ����˺�
            Destroy(gameObject);                            //�ݻ��ϰ���(����г����˺�������˴�Ҫ�������ģ��磺����)
        }
    }
}
