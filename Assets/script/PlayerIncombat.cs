using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class PlayerIncombat : MonoBehaviour
{
    public Transform playerTrans;
    private BoxCollider2D playerCollider;
    private SpriteRenderer PlayerRender;
    public bag playerBag;
    public BoxCollider2D reBoundColli;
    public GameObject MagicBal;
    public Transform MagicBallTrans;
    public BoxCollider2D shortBladeColli;
    public SpriteRenderer LightTingsprite;
    public boss boss;

    public int maxHealth;                //�����������ֵ
    public int health;

    public float moveTime;               //�����ƶ�ʱ��
    public float moveDistance;           //�����ƶ�����
    public float invincibleTime;         //�����޵�ʱ��
    private float startInvincibleTime;                                     //

    public float roadUp;                 //������·λ��  ע��Ҫ���ƶ�����ͬ������
    public float roadMiddle;
    public float roadDown;

    public float InvincibleCd;//�޵м��ܵ�Cd
    private float InvincibleStartCd;
    public float reBoundCd;//�����ϰ���CD
    private float startReBoundCd;
    public float wandCd;//�������ɷ���cd
    private float startWandCd;
    public float shortBladeCd;//������ȴʱ��
    private float shortBladeStartCd;
    public float finalJudgementCd;//�Ʋ���ȴʱ��
    private float startFinalJudgement;
    public int WindNum;//һ�μ������ɷ������
    private float RollBackTime;//��ҡʱ��
    public float wandRollBackTIme;//���Ⱥ�ҡʱ��
    public float shortBladeRollBackTime;
    public float ReBoundInvincibTime;//���ܵ��޵�ʱ��
    public float JudementRollBackTime;//�����Ʋú�ҡ

    public float skillInvincibleTime;//�޵ж೤ʱ��
    public float reBoundTime;//��������ʱ��
    public float ShortBladeTime;//����Ч������ʱ��

    public Image skillCD;
    public float CDtime;

    public int judgementDamage;//�Ʋü����˺�

    bool isCD;
    private bool isDamage;
    private bool isSkillInvincible;
    //�ж�����Ƿ����ʹ�ü��ܵ�boolֵ
    public bool haveShield;
    public bool haveWand;
    public bool CanReBound;
    public bool haveShortBlade;
    public bool haveFinalJudgement;

    private bool isUseShield;
    private bool isUseWand;
    private bool isUseReBound;
    private bool isUseShortBlade;
    private bool isUseFinalJudgement;
    // Start is called before the first frame update
    void Start()
    {
        startInvincibleTime = invincibleTime;
        invincibleTime = 0;
        InvincibleStartCd = InvincibleCd;
        InvincibleCd = 0;
       startWandCd = wandCd ;
        wandCd = 0;
         startReBoundCd=reBoundCd;
        reBoundCd = 0;
        invincibleTime = 0;
        shortBladeStartCd = shortBladeCd;
        shortBladeCd = 0; 
        startFinalJudgement = finalJudgementCd;
        finalJudgementCd = 0;
        PlayerRender = GetComponent<SpriteRenderer>();
        health = maxHealth;              //��ʼ������ֵ
        playerCollider = GetComponent<BoxCollider2D>();
        isCD = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Skill();
        CanInvincble();//�޵к���
        TurnColor();
         invincibleTime -= Time.deltaTime;//�޵�ʱ����٣����޵�ʱ���ж��Ƿ��޵�
       RollBackTime -= Time.deltaTime;
        ReBound();
        wend();
        shorBlade();
        FinalJudgement();
    }
    void TurnColor()
    {
        if (invincibleTime > 0&& PlayerRender.color != Color.red && isSkillInvincible)
        {
            PlayerRender.color = Color.green;
        }
        if (invincibleTime <= 0)
        {
            isSkillInvincible = false;
        }
        if (!isDamage && invincibleTime <= 0)
        {

            PlayerRender.color = Color.white;
        }
    }
    private void OnEnable()
    {
        //�Ȱѵ��ߺ�����ʼ�����¼�����
        eventsystem.Instance.setUpOrAdd("����", PlayerShield);//��string�����͵�������Ӧ����ͬ
        eventsystem.Instance.setUpOrAdd("ħ������", PlayerWand);
        eventsystem.Instance.setUpOrAdd("��������", playerReBound);
        eventsystem.Instance.setUpOrAdd(" ���ݶ���", PlayerShortBlade);
        eventsystem.Instance.setUpOrAdd("����ʥ��", PlayerFinalJudgement);
        eventsystem.Instance.setUpOrAdd("���ʹ�ö���", PlayerIsUseShield);//��string�����͵�������Ӧ����ͬ
        eventsystem.Instance.setUpOrAdd("���ʹ��ħ������", PlayerIsUseWand);
        eventsystem.Instance.setUpOrAdd("���ʹ�÷�������", playerIsUseReBound);
        eventsystem.Instance.setUpOrAdd(" ���ʹ�ò��ݶ���", PlayerIsUseShortBlade);
        eventsystem.Instance.setUpOrAdd("���ʹ������ʥ��", PlayerIsUseFinalJudgement);
        //ʹ����ˢ�º���ǰһ�������Ѿ���ȡ�ĵ�����Ч
        for (int i = 0; i < playerBag.items.Count; i++)
        {
            if (playerBag.items[i].isGet)
            {
                eventsystem.Instance.EventInvoke(playerBag.items[i].Name);
            }
        }
    }
    private void Awake()
    {
        InvincibleStartCd = InvincibleCd;
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))//���°�����W��
        {
            if (playerTrans.position.y == roadUp)  //�������·�������ƶ�
            {
                return;
            }
            else if ((playerTrans.position.y == roadMiddle || playerTrans.position.y == roadDown )&&RollBackTime<=0) //�����м�or��·���ƶ�
            {
                playerTrans.DOMoveY(moveDistance, moveTime).SetRelative();
                soundManager.jumpingSound();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))//���°�����S��
        {
            if (playerTrans.position.y == roadDown) //�������·�������ƶ�
            {
                return;
            }
            else if ((playerTrans.position.y == roadMiddle || playerTrans.position.y == roadUp) && RollBackTime <= 0) //�����м�or��·���ƶ�
            {
                playerTrans.DOMoveY(-moveDistance, moveTime).SetRelative();
                soundManager.jumpingSound();
            }
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
        if (invincibleTime<=0)                //�ܵ��˺�
        {
              health -= damage;
            isDamage = true;
            eventsystem.Instance.EventInvoke("playerTakeDamage");//���ļ���
            Debug.Log("playerTakeDamage");
            if (PlayerRender.color != Color.green)
            {
                PlayerRender.color = Color.red;//��ɺ�ɫ�������ã�
                StartCoroutine("turnWhit");
            }
            if (health <= 0)
            {
                Debug.Log("die");
            }
            invincibleTime = startInvincibleTime;
        }                 
    }
   IEnumerator turnWhit()
    {
        yield return new WaitForSeconds(0.4f);
        PlayerRender.color = Color.white;
        isDamage = false;
    }
    public void CanInvincble()//��k�����޵еĺ���(����)
    {
        InvincibleCd -= Time.deltaTime;
        if (haveShield && InvincibleCd<=0)//�ж��Ƿ���Խ����޵�
        {
            if (isUseShield)
            {
                invincibleTime = skillInvincibleTime;//�޵�״̬����   
                InvincibleCd = InvincibleStartCd;
                isSkillInvincible = true;
            }
        }
    }
  public void ReBound()//�������ܵĺ���
    {
        reBoundCd -= Time.deltaTime;
        if (CanReBound && reBoundCd <= 0)//�ж��Ƿ���Խ����޵�
        {
            if (isUseReBound)
            {
                print("�ɹ���������");
                reBoundColli.enabled = true;
                StartCoroutine("deleteColli");
                reBoundCd = startReBoundCd;
                invincibleTime = ReBoundInvincibTime;
                isSkillInvincible = true;
            }
        }
    }
    public void wend()//���ɷ���ĺ���
    {
        wandCd -= Time.deltaTime;
        if (haveWand && wandCd <= 0)//�ж��Ƿ���Խ����޵�
        {
            if (isUseWand)
            {
                print("�ɹ�����wind����");
                wandCd = startWandCd;
                RollBackTime = wandRollBackTIme;
                StartCoroutine("lunch");
            }
        }
    }
    IEnumerator lunch()
    {
        for (int i = 0; i < WindNum; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(MagicBal,MagicBallTrans.position, Quaternion.identity);
        }
    }
    IEnumerator deleteColli()
    {
        yield return new WaitForSeconds(reBoundTime);
        reBoundColli.enabled = false;
        isSkillInvincible = false;
    }
    public void shorBlade()//���еĺ���
    {
        shortBladeCd-= Time.deltaTime;
        if (haveShortBlade && shortBladeCd <= 0)//�ж��Ƿ���Խ����޵�
        {
            if (isUseShortBlade)
            {
                print("�ɹ�����shortBlade����");
                shortBladeColli.enabled = true;
                StartCoroutine("deleteShortBladeColli");//�������е���ײ��
                shortBladeCd = shortBladeStartCd;
                RollBackTime = shortBladeRollBackTime;
                
            }
        }
    }
    IEnumerator deleteShortBladeColli()//�������еĺ���
    {
        yield return new WaitForSeconds(ShortBladeTime);
        shortBladeColli.enabled = false;
        
    }
    public void FinalJudgement()//�����Ʋ�
    {
        finalJudgementCd-= Time.deltaTime;
        if (haveFinalJudgement && finalJudgementCd<= 0)//�ж��Ƿ���Խ����޵�
        {
            if (isUseFinalJudgement)
            {
                print("�ɹ�����FinalJudgement����");
                
                StartCoroutine("generateLighting");
                finalJudgementCd = startFinalJudgement;
                RollBackTime = JudementRollBackTime;
                
            }
        }
    }
    IEnumerator generateLighting()
    {
        yield return new WaitForSeconds(0.5f);
        LightTingsprite.enabled = true;
        print("�Ʋ�");
        boss.BossHealth -=judgementDamage;
        StartCoroutine("deleteLighting");
    }
    IEnumerator deleteLighting()
    {
        yield return new WaitForSeconds(0.4f);
        LightTingsprite.enabled = false;
    }
    //����д��������boolֵ�Ľ���
    void PlayerShield()//����޵�
    {
       haveShield = true;
    }
    void PlayerWand()//��ҵķ���
    {
        haveWand = true;
    }
    void playerReBound()//��ҷ�������
    {
        CanReBound = true;
    }
    void PlayerShortBlade()
    {
        haveShortBlade = true;
    }
    void PlayerFinalJudgement()
    {
        haveFinalJudgement = true;
    }
    //����Boolֵ��ͬ��
    void PlayerIsUseShield()//����޵�
    {
        isUseShield = true;
    }
    void PlayerIsUseWand()//��ҵķ���
    {
       isUseWand = true;
    }
    void playerIsUseReBound()//��ҷ�������
    {
        isUseReBound = true;
    }
    void PlayerIsUseShortBlade()
    {
        isUseShortBlade = true;
    }
    void PlayerIsUseFinalJudgement()
    {
        isUseFinalJudgement = true;
    }
}
