using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailBoss_AI : MonoBehaviour {
	//子弹类型
	public List<GameObject> bulletPerfabs;
	//子弹射出点
	public Transform[] shotPoint = new Transform[2];

	public Transform vida;
	ParticleSystem smoke;

	bool secondStage = false;

	//水平射
	bool hShotable = false;
	int hShotNum = 0;
	public float hShotInterval = 1.5f;  //水平射击间隔

	//抛射
	bool pShotable = false;
	int pShotNum = 0;
	int pShotAmmoNum = 1;
	public float pShotInterval = 4f;    //抛物线射击间隔
	private float maxPShotHigh = 6.5f;
	private float pShotTime = 1.0f;

	//跟踪
	bool fShotable = false;
	int fShotNum = 0;
	public float fShotInterval = 4f;


	// Use this for initialization
	void Start () {

		vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		smoke = GetComponent<ParticleSystem>();
		smoke.Stop();

		Invoke("FirstAttack",4.0f);
	}

	// Update is called once per frame
	void Update () {

		if(hShotable)
		{
			HorizontalShot();
		}	
		else if (pShotable)
		{
			ParabolaShot();
		}
		else if (fShotable)
		{
			FollowShot();
		}

		//如果生命低于40，进入第二阶段
		if (!secondStage&&GetComponent<FailBoss>().health < 40)
		{
			EnterSecondStage();
		}
			

	}

	//进入第二阶段
	public void EnterSecondStage()
	{
		secondStage = true;
		//停止当前所有攻击手段
		CancelInvoke();

		GetComponent<FailBoss>().cameraShake.ShakeOnce();

		//动画
		GetComponent<Animator>().SetTrigger("EnterSecondStage");

		//冒烟特效
		smoke.Play();

		FirstAttack();
	}

    //水平投射
    void HorizontalShot()
    {	

			//随机第0~N-1种子弹
			var bulletObject = Instantiate(bulletPerfabs[1], shotPoint[1].position, transform.rotation, transform);
			//子弹速度5f
			bulletObject.GetComponent<Bullet>().speed = 13f;

			Vector3 scale = new Vector2(bulletObject.transform.localScale.x * -Mathf.Sign(transform.localScale.x), bulletObject.transform.localScale.y);
			bulletObject.transform.localScale = scale;

		

		hShotable = false;
		hShotNum--;

		//如果射完了，证明可以进入第二攻击
		if (hShotNum <= 0)
		{
			Invoke("SecondAttack",pShotInterval);
		}
		//否则继续射
		else
		{
			Invoke("HorizontalShot",hShotInterval);
		}
    }

    //抛物线投射
    void ParabolaShot()
    {
        float distanceX = vida.position.x - transform.position.x;
        //求出x轴速度
        float Vx = distanceX / pShotTime;
        //求出y轴速度
        float Vy = maxPShotHigh / pShotTime;

		for (int i = 0; i < pShotAmmoNum; ++i)
		{
			//随机第0~N-1种子弹
			var bulletObject = Instantiate(bulletPerfabs[0], shotPoint[0].position, transform.rotation, transform);
			bulletObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Vx * 0.0062f + i * 0.0045f, Vy * 0.005f));
		}

		pShotable = false;
		pShotNum--;

		//如果射完了
		if (pShotNum <= 0)
		{
			//如果BOSS进入第二阶段，证明可以进入第三攻击
			if (secondStage)
			{
				Invoke("ThirdAttack", 1.0f);
			}
			//不然重新第一攻击
			else
			{
				Invoke("FirstAttack", hShotInterval);
			}
		}
		//否则继续射
		else
		{
			Invoke("ParabolaShot",pShotInterval);
		}
	}

	//跟踪发射
	void FollowShot()
	{


		Instantiate(bulletPerfabs[2], shotPoint[0].position, transform.rotation, transform);

		fShotable = false;
		fShotNum--;

		//如果射完了
		if (fShotNum <= 0)
		{

			//重新第一攻击
			Invoke("FirstAttack", hShotInterval);
		}
		//否则继续射
		else
		{
			Invoke("FollowShot", fShotInterval);
		}

	}
	
	//第一阶段攻击
	public void FirstAttack()
	{
		if (secondStage)
		{
			hShotInterval = 2f;
		}
		else
		{
			hShotInterval = 3f;
		}
		//允许发射4颗子弹
		hShotable = true;
		hShotNum = 5;
	}


	//第二阶段攻击
	public void SecondAttack()
	{
		if (secondStage)
		{
			pShotAmmoNum = 8;
			pShotInterval = 1f;
		}
		else
		{
			pShotAmmoNum = 5;
			pShotInterval = 1.5f;
		}

		//允许抛射1次子弹
		pShotable = true;
		pShotNum = 2;
	}


	//第三阶段攻击
	public void ThirdAttack()
	{
		if (secondStage)
		{
			fShotable = true;
			fShotInterval = 2f;
			fShotNum = 2;
		}


	}

}
