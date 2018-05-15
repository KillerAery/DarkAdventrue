using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : Biology{
	/*蛋属性*/
    public string playerType;
	public int health = 2;
	public bool invincivle = false;
	public bool guardian = false;

	/*移动*/
	public float maxSpeed = 5f;
    [HideInInspector]
    public bool facingRight = true;

    /*跳跃*/
    public float jumpForce = 900f;
    [HideInInspector]public bool grounded = false;
    [HideInInspector]public int jumpable = 0;
	[HideInInspector] public bool jump = false;
	[HideInInspector]public float jumpTimer = 0.0f;

    /*冲撞*/
    [HideInInspector]public bool charge = false;
    [HideInInspector] public float chargeTimer = 2.0f;
    [HideInInspector]public bool inCharging = false;
    public float chargeColdTime = 2.0f;
    public float chargeSpeed = 20f;

    /*辅助数据*/
	protected Transform checkPoint;
    protected GameController gameController;
    protected UIManager uiManager;
	public HealthView healthView;
	public ParticleSystem guardEffect;
	public PoisonCircle catchVida;

	void Awake()
    {
    
    }

    // Use this for initialization
    void Start () {
        //绑定一堆东西
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        checkPoint = GameObject.Find("checkPoint").GetComponent<Transform>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

		transform.position = checkPoint.position;        //出生点位置设置在检查点位置
		healthView.SetHealthImage(health);              //更新生命值图标
		guardEffect.Stop();
	}

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        //若碰到检查点，则设置之
        if (collision.gameObject.tag == "checkPoint")
        {
            checkPoint = collision.gameObject.transform;
        }
        //若碰到底部，死亡
        else if (collision.gameObject.tag == "bottom")
        {
			//将生命变为1，直接死亡。
			health = 1;
            Die();
        }
    }

	//获取二段跳技能
	public void GetDoubleJumpSkill()
	{
		playerType = Tags.YingjianDan;
	}

    public void EatDamage()
    {
        //如果不是冲刺状态 也不是无敌状态，则死亡
        if (!inCharging&&!invincivle) Die();
    }

	public void ReceiveGuard()
	{
		guardian = true;
		guardEffect.Play();
	}

	//Boss战结束后，获得的守护仅仅只是个特效
	public void ReceiveGuard_AfterBoss()
	{
		guardEffect.Play();
	}

	public void LoseGuard()
	{
		guardian = false;
		guardEffect.Stop();
		guardEffect.Clear();
	}

	public void StartInvincivle()
	{
		invincivle = true;
	}

	public void EndInvincivle()
	{
		invincivle = false;
	}

    //重置vida状态
    void ResetVida()
	{

		GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		health = 5;
		healthView.SetHealthImage(health);//更新生命值图标
		transform.position = checkPoint.position;

		//如果有追赶的毒圈，则重设毒圈位置
		if(catchVida.catching)
		catchVida.ResetPosition();

		invincivle = true;
		Invoke("EndInvincivle", 1.5f);
	}

    //死亡函数
    public override void Die()
    {
		health -= 1;
		healthView.SetHealthImage(health);
		JumpBack();
		GetComponent<Animator>().SetTrigger("Invincivle");

		invincivle = true;
		//如果还有生命剩余，则不死，且暂时无敌
		if (health > 0)
		{
			Invoke("EndInvincivle", 1.5f);
		}
		else
		{
			//死亡音效
			SoundManager.GetInstance().PlaySoundEffect(SoundManager.Vida_Die, transform.position);
			//运行死亡特效
			GameObject.Find("EffectManager").GetComponent<EffectManager>().PlayParticleEffect(FailDie_ParticleEffect, transform);
			//重置vida状态
			ResetVida();
		}
	}



	//往后跳
	//收到伤害就往后跳
	public void JumpBack()
	{
		float s = 4f;
		GetComponent<Rigidbody2D>().velocity = new Vector2(facingRight ? -s : s,10f);
	}

}
