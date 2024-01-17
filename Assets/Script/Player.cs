using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{
    public Transform playerTrans;
    private BoxCollider2D playerCollider;


    public int maxHealth;                //�����������ֵ
    int health;

    public float moveTime;               //�����ƶ�ʱ��
    public float moveDistance;           //�����ƶ�����
    public float invincibleTime;         //�����޵�ʱ��
    public bool isInvincible;            //�޵�״̬

    public float roadUp;                 //������·λ��  ע��Ҫ���ƶ�����ͬ������
    public float roadMiddle;
    public float roadDown;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;              //��ʼ������ֵ
        playerCollider = GetComponent<BoxCollider2D>();
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))//���°�����W��
        {
            if (playerTrans.position.y == roadUp)  //�������·�������ƶ�
            {
                return;
            }
            else if (playerTrans.position.y == roadMiddle || playerTrans.position.y == roadDown) //�����м�or��·���ƶ�
            {
                playerTrans.DOMoveY(moveDistance, moveTime).SetRelative();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))//���°�����S��
        {
            if (playerTrans.position.y == roadDown) //�������·�������ƶ�
            {
                return;
            }
            else if (playerTrans.position.y == roadMiddle || playerTrans.position.y == roadUp) //�����м�or��·���ƶ�
            {
                playerTrans.DOMoveY(-moveDistance, moveTime).SetRelative();
            }
        }
    }

    public void TakeDamage (int damage)  //��ɫ����
    {
        if (isInvincible)                //�������޵�״̬������˺�
        {
            return;
        }
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("die");
        }
        isInvincible = true;             //�޵�״̬����
        StartCoroutine(WaitInvincible());//����Э�̴����޵�ʱ��
    }

    IEnumerator WaitInvincible()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

}
