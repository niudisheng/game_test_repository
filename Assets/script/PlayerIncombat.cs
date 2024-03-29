using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;


public class PlayerIncombat : MonoBehaviour
{
    public int sceneNum;

    public GameObject FinalPoint;
    public Transform playerTrans;
    private BoxCollider2D playerCollider;
    private SpriteRenderer PlayerRender;
    public bag playerBag;
    [Header("更改部分")]
    public GameObject reBound;
    BoxCollider2D reBoundColli;
    Renderer reBoundRender;
    public GameObject Bound;
    BoxCollider2D BoundColli;
    Renderer BoundRender;

    public GameObject MagicBal;
    public Transform MagicBallTrans;
    public BoxCollider2D shortBladeColli;
    public SpriteRenderer LightTingsprite;
    public boss boss;
    public point point;
    public bool finishGuide;
    

    public int maxHealth;                //设置最大生命值
    public int health;

    public float moveTime;               //设置移动时间
    //public float moveDistance;           //设置移动距离
    public float invincibleTime;         //设置无敌时间
    private float startInvincibleTime;                                     //

    public float roadUp;                 //设置三路位置  注意要与移动距离同步调整
    public float roadMiddle;
    public float roadDown;

    public float InvincibleCd;//无敌技能的Cd
    private float InvincibleStartCd;
    public float reBoundCd;//反弹障碍物CD
    private float startReBoundCd;
    public float wandCd;//法杖生成法球cd
    private float startWandCd;
    public float shortBladeCd;//短刃冷却时间
    private float shortBladeStartCd;
    public float finalJudgementCd;//制裁冷却时间
    private float startFinalJudgement;
    public int WindNum;//一次技能生成法球个数
    private float RollBackTime;//后摇时间
    public float wandRollBackTIme;//法杖后摇时间
    public float shortBladeRollBackTime;
    public float ReBoundInvincibTime;//护盾的无敌时间
    public float JudementRollBackTime;//终阎制裁后摇

    public float skillInvincibleTime;//无敌多长时间
    public float reBoundTime;//反弹持续时间
    public float ShortBladeTime;//短刃效果持续时间

    public Image skillCD_One;
    public Image skillCD_Two;

    public int judgementDamage;//制裁技能伤害

    bool isCD;
    public bool isBloodLock;//是否锁血
    public bool isChangeToNextScene;
    private bool isDamage;
    private bool isSkillInvincible;
    //判断玩家是否可以使用技能的bool值
    public bool haveShield;
    public bool haveWand;
    public bool CanReBound;
    public bool haveShortBlade;
    public bool haveFinalJudgement; 

    public bool isChangeRoles;
    public Role role1;
    public Role role2;
    public GameObject[] roles = new GameObject[2];

    private bool isUseShield;
    private bool isUseWand;
    private bool isUseReBound;
    private bool isUseShortBlade;
    private bool isUseFinalJudgement;
    
    // Start is called before the first frame update
    void Start()
    {
        reBoundColli = reBound.GetComponent<BoxCollider2D>();
        reBoundRender = reBound.GetComponent<Renderer>();
        BoundColli = reBound.GetComponent<BoxCollider2D>();
        BoundRender = reBound.GetComponent<Renderer>();

        isUseShield = false;
        isUseWand = false;
        isUseReBound = false;
        isUseShortBlade = false;
        isUseFinalJudgement = false;
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
        health = maxHealth;              //初始化生命值
        playerCollider = GetComponent<BoxCollider2D>();
        isCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SkillOne();
        SkillTwo();
        CanInvincble();//无敌函数
        TurnColor();
        invincibleTime -= Time.deltaTime;//无敌时间减少，由无敌时间判断是否无敌
        RollBackTime -= Time.deltaTime;
        ReBound();
        wend();
        shorBlade();
        FinalJudgement();
        playerDeath();
        // Debug.Log(isUseFinalJudgement);
        // Debug.Log(isUseReBound);
        // Debug.Log(isUseShield);
        // Debug.Log(isUseShortBlade);
        // Debug.Log(isUseWand);
        IsChangeToNextScene();
        IsChangeRoles();
    }

   void IsChangeRoles()
    {
        if (isChangeRoles)
        {
           if (role1.RokeIsUse)
            {
                roles[0].gameObject.SetActive(true);
                roles[1].gameObject.SetActive(false);
            }
            if (role2.RokeIsUse)
            {
                roles[0].gameObject.SetActive(false);
                roles[1].gameObject.SetActive(true);
            }
        }
    }
    void IsChangeToNextScene()
    {
        if (isChangeToNextScene&&health<=0)
        {
            playerBag.items.Clear();
            sceneManager.Instance.changeScene(sceneNum);
        }
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
        Time.timeScale = 1;
        //先把道具函数初始化到事件中心
        eventsystem.Instance.clearAll();
        eventsystem.Instance.setUpOrAdd("盾牌", PlayerShield);//此string变量和道具名字应该相同
        eventsystem.Instance.setUpOrAdd("魔力法杖", PlayerWand);
        eventsystem.Instance.setUpOrAdd("反弹护盾", playerReBound);
        eventsystem.Instance.setUpOrAdd("不休短刃", PlayerShortBlade);
        eventsystem.Instance.setUpOrAdd("终焉圣裁", PlayerFinalJudgement);
        eventsystem.Instance.setUpOrAdd("玩家使用盾牌", PlayerIsUseShield);//此string变量和道具名字应该相同
        eventsystem.Instance.setUpOrAdd("玩家使用魔力法杖", PlayerIsUseWand);
        eventsystem.Instance.setUpOrAdd("玩家使用反弹护盾", playerIsUseReBound);
        eventsystem.Instance.setUpOrAdd("玩家使用不休短刃", PlayerIsUseShortBlade);
        eventsystem.Instance.setUpOrAdd("玩家使用终焉圣裁", PlayerIsUseFinalJudgement);
        //使场景刷新后在前一个场景已经获取的道具生效
        for (int i = 0; i < playerBag.items.Count; i++)
        {
            if (playerBag.items[i].isGet)
            {
                eventsystem.Instance.EventInvoke(playerBag.items[i].Name);
            }
        }
    }
   void playerDeath()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            if (FinalPoint)
            {
                 FinalPoint.SetActive(true);
            }
            
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        InvincibleStartCd = InvincibleCd;
    }
    void Move()
    {
        Debug.Log("000");
        if (Input.GetKeyDown(KeyCode.W))//按下按键“W”
        {
            Debug.Log("123");
            if (finishGuide)
            {
                if (playerTrans.position.y == roadUp)  //处于最高路，不再移动
                {
                    return;
                }
                else if (playerTrans.position.y == roadMiddle && RollBackTime <= 0) //处于中间or下路，移动
                {
                    playerTrans.DOMoveY(roadUp, moveTime);
                    soundManager.Instance.playSFX("jump");
                }
                else if (playerTrans.position.y == roadDown && RollBackTime <= 0) //处于中间or下路，移动
                {
                    playerTrans.DOMoveY(roadMiddle, moveTime);
                    soundManager.Instance.playSFX("jump");
                }

            }

        }
        if (Input.GetKeyDown(KeyCode.S))//按下按键“S”
        {
            if (finishGuide)
            {
                if (playerTrans.position.y == roadDown) //处于最低路，不再移动
                {
                    return;
                }
                else if (playerTrans.position.y == roadMiddle && RollBackTime <= 0) //处于中间or上路，移动
                {
                    playerTrans.DOMoveY(roadDown, moveTime);
                    soundManager.Instance.playSFX("jump");
                }
                else if (playerTrans.position.y == roadUp && RollBackTime <= 0) //处于中间or上路，移动
                {
                    playerTrans.DOMoveY(roadMiddle, moveTime);
                    soundManager.Instance.playSFX("jump");
                }
            }      
        }
    }

    void SkillOne()
    {
        if (playerBag.items.Count >= 1)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {

                if (skillCD_One.fillAmount == 0f)        //技能处于就绪状态
                {
                    skillCD_One.fillAmount = 1f;
                    isCD = true;
                }
            }
            if (isCD)                                //技能处于冷却状态
            {
                skillCD_One.fillAmount -= 1f / playerBag.items[0].Cd * Time.deltaTime;
            }
        }
            
    }

    public void MoveUP()
    {
        playerTrans.DOMoveY(roadUp, moveTime);
        soundManager.Instance.playSFX("jump");
        //soundManager.jumpingSound();
    }

    public void MoveDown()
    {
        playerTrans.DOMoveY(roadDown, moveTime);
        soundManager.Instance.playSFX("jump");
        //soundManager.jumpingSound();
    }

    void SkillTwo()
    {
        if (playerBag.items.Count >= 2)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                if (skillCD_Two.fillAmount == 0f)        //技能处于就绪状态
                {

                    skillCD_Two.fillAmount = 1f;
                    isCD = true;
                }
            }
            if (isCD)                                //技能处于冷却状态
            {
                skillCD_Two.fillAmount -= 1f / playerBag.items[1].Cd * Time.deltaTime;
            }
        }
            
    }

    public void TakeDamage (int damage)  //角色受伤
    {
        if (invincibleTime<=0)                //受到伤害
        {
              health -= damage;
            isDamage = true;
            if (isBloodLock&&health<=0)
            {
                health += damage;
            }
            eventsystem.Instance.EventInvoke("playerTakeDamage");//爱心减少
            Debug.Log("playerTakeDamage");
            if (PlayerRender.color != Color.green)
            {
                PlayerRender.color = Color.red;//变成红色（测试用）
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
    public void CanInvincble()//按k键就无敌的函数(盾牌)
    {
        InvincibleCd -= Time.deltaTime;
        if (haveShield && InvincibleCd<=0)//判断是否可以解锁无敌
        {   //不无敌的情况
            if (isUseShield == true)
            {
                isUseShield = false;
                print("已经使用无敌盾牌");
                invincibleTime = skillInvincibleTime;//无敌状态开启   
                InvincibleCd = InvincibleStartCd;
                isSkillInvincible = true;
                BoundRender.enabled=true;

            }
            else
            {
                BoundRender.enabled=false;
            }
        }
    }
  public void ReBound()//反弹护盾的函数
    {
        reBoundCd -= Time.deltaTime;
        if (CanReBound && reBoundCd <= 0)//判断是否可以解锁无敌
        {
            if (isUseReBound==true)
            { 
                isUseReBound = false;
                print("成功开启反弹护盾技能");
                reBoundColli.enabled = true;
                
                reBoundRender.enabled = true;
                StartCoroutine("deleteColli");
                reBoundCd = startReBoundCd;
                invincibleTime = ReBoundInvincibTime;
                isSkillInvincible = true;
               
            }
        }
    }
    public void wend()//生成发球的函数
    {
        wandCd -= Time.deltaTime;
        if (haveWand && wandCd <= 0)//判断是否可以解锁无敌
        {
            if (isUseWand == true)
            {
                isUseWand = false;
                print("成功开启wind技能");
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
            yield return new WaitForSeconds(0.5f);
            Instantiate(MagicBal,MagicBallTrans.position, Quaternion.identity); 
            soundManager.Instance.playSFX("fireBall");
        }
    }
    IEnumerator deleteColli()
    {
        yield return new WaitForSeconds(reBoundTime);
        reBoundColli.enabled = false;
        reBoundRender.enabled = false;
        isSkillInvincible = false;
    }
    public void shorBlade()//短刃的函数
    {
        shortBladeCd-= Time.deltaTime;
        if (haveShortBlade && shortBladeCd <= 0)//判断是否可以解锁无敌
        {
            if (isUseShortBlade == true)
            {
                isUseShortBlade = false;
                print("成功开启短刃技能");
                shortBladeColli.enabled = true;
                StartCoroutine("deleteShortBladeColli");//消除短刃的碰撞体
                shortBladeCd = shortBladeStartCd;
                RollBackTime = shortBladeRollBackTime;
                
               print("成功开启shortBlade技能");
            }
        }
    }
    IEnumerator deleteShortBladeColli()//消除短刃的函数
    {
        yield return new WaitForSeconds(ShortBladeTime);
        shortBladeColli.enabled = false;
        StopCoroutine("deleteShortBladeColli");
    }
    public void FinalJudgement()//终阎制裁
    {
        finalJudgementCd-= Time.deltaTime;
        if (haveFinalJudgement && finalJudgementCd<= 0)//判断是否可以解锁无敌
        {
            if (isUseFinalJudgement == true)
            {
                isUseFinalJudgement = false;
                print("成功开启FinalJudgement技能");
                
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
        print("制裁");
        point.TimePoint +=judgementDamage;
        StartCoroutine("deleteLighting");
    }
    IEnumerator deleteLighting()
    {
        yield return new WaitForSeconds(1.2f);
        LightTingsprite.enabled = false;
    }
    //下面写各个道具bool值的解锁
    void PlayerShield()//玩家无敌
    {
       haveShield = true;
    }
    void PlayerWand()//玩家的法杖
    {
        haveWand = true;
    }
    void playerReBound()//玩家反弹道具
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
    //按键Bool值的同步
    void PlayerIsUseShield()//玩家无敌
    {
        isUseShield = true;
    }
    void PlayerIsUseWand()//玩家的法杖
    {
       isUseWand = true;
    }
    void playerIsUseReBound()//玩家反弹道具
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

    public void FinishGuide()
    {
        finishGuide = true;
    }

    public void InGuide()
    {
        finishGuide = false;
    }
}
