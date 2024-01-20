using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class PlayerIncombat : MonoBehaviour
{
    public Transform playerTrans;
    private BoxCollider2D playerCollider;
    private Animator playerAnim;


    public int maxHealth;                //�����������ֵ
    int health;

    public float moveTime;               //�����ƶ�ʱ��
    public float moveDistance;           //�����ƶ�����
    public float invincibleTime;         //�����޵�ʱ��
    bool isInvincible;            //�޵�״̬

    public float roadUp;                 //������·λ��  ע��Ҫ���ƶ�����ͬ������
    public float roadMiddle;
    public float roadDown;

    public Image skillCD;
    public float CDtime;
    bool isCD;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;              //��ʼ������ֵ
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
        isInvincible = false;
        isCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Skill();

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
        if (playerTrans.position.y == roadDown || playerTrans.position.y == roadUp || playerTrans.position.y == roadMiddle)
        {
            playerAnim.SetBool("Move", false);
        }
        else
        {
            playerAnim.SetBool("Move", true);
        }
    }


    void Skill()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            if (skillCD.fillAmount == 0f)        //���ܴ��ھ���״̬
            {
                
                skillCD.fillAmount = 1f;
                isCD = true;
            }
        }
        if (isCD)                                //���ܴ�����ȴ״̬
        {
            skillCD.fillAmount -= 1f / CDtime * Time.deltaTime;
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
        playerAnim.SetBool("Hurt", true);
        StartCoroutine(WaitInvincible());//����Э�̴����޵�ʱ��
    }

    IEnumerator WaitInvincible()
    {
        
        yield return new WaitForSeconds(invincibleTime);
        Debug.Log("000");
        playerAnim.SetBool("Hurt", false);
        isInvincible = false;
    }

}
