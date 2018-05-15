using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaController : MonoBehaviour
{
	public Vida vida;
	private RaycastHit2D checkResult;
	public Transform[] groundChecks = new Transform[3];

	private Rigidbody2D body;

	public bool controllable = true;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		float dt = Time.deltaTime;
		//累计时间
		vida.chargeTimer += dt;
		vida.jumpTimer += dt;

		//TODO 待优化代码
		//是否到地面 用三个groundCheck来检测
		for (int i = 0; i < 3; ++i)
		{
			checkResult = Physics2D.Linecast(transform.position, groundChecks[i].position, 1 << LayerMask.NameToLayer("Ground"));
			vida.grounded = checkResult;
			if (vida.grounded) break;
		}

		if (vida.grounded)
		{
			//火箭蛋（硬件蛋特殊技能）
			if (vida.playerType == Tags.YingjianDan)
			{
				vida.jumpable = 1;

			}
		}

		//跳跃
		//按下K时
		if (Input.GetKeyDown(KeyCode.K) && vida.jumpTimer >= 0.03f)
		{
			if (vida.grounded)
			{
				//允许跳跃
				vida.jumpTimer = 0.0f;
				vida.jump = true;
			}
			else if (vida.jumpable > 0)
			{
				vida.jumpable--;
				//允许跳跃
				vida.jumpTimer = 0.0f;
				vida.jump = true;
			}

		}

		////普通攻击
		//if (Input.GetButton("Fire1"))
		//{
		//    GetComponent<Animator>().SetTrigger("Slash");
		//}

		//冲撞时间持续 0.N秒
		if (vida.inCharging == true)
		{
			if (vida.chargeTimer >= 0.3f)
			{
				body.velocity = new Vector2(0, 0);
				vida.inCharging = false;
			}
			else
			{
				body.velocity = new Vector2((vida.facingRight ? 1 : -1) * vida.chargeSpeed, body.velocity.y);
			}
		}

		//冲撞
		if (Input.GetKeyDown(KeyCode.J) && vida.chargeTimer > vida.chargeColdTime)
		{
			vida.charge = true;
		}

	}

	//停止控制
	public void StopControll()
	{
		//速度停下
		body.velocity = new Vector2(0, 0);
		//跑步动作停下
		GetComponent<Animator>().SetFloat("Speed", 0);
		GetComponent<Animator>().speed = 1;
		//停止控制
		controllable = false;
	}

	//恢复控制
	public void ResumeControll()
	{
		controllable = true;
	}



	void FixedUpdate()
	{
		if (!controllable) return;

		//处理水平移动（根据水平输入）
		HorizontalMoveControll();
		//处理跳跃
		JumpControll();
		//碰撞控制
		ChargeControll();
	}


	//翻转
	void Flip()
	{
		vida.facingRight = !vida.facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//水平移动（根据水平输入值）
	void HorizontalMoveControll()
	{
		float h = Input.GetAxis("Horizontal");
		//设置水平移动速度
		if (Mathf.Abs(body.velocity.x) <= vida.maxSpeed + 10.0f)
		{
			float vx = 0;
			//float vy = 0;
			if (checkResult.rigidbody)
			{
				vx = checkResult.rigidbody.velocity.x;
				//vy = CheckResult.rigidbody.velocity.y;
			}


			if (Mathf.Abs(h) > 0.15f)
			{
				body.velocity = new Vector2(Mathf.Sign(h) * vida.maxSpeed + vx, body.velocity.y);
				GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(h));
				GetComponent<Animator>().speed = Mathf.Abs(h) * 3;
			}
			else
			{
				body.velocity = new Vector2(vx, body.velocity.y);
				GetComponent<Animator>().SetFloat("Speed", 0);
				GetComponent<Animator>().speed = 1;
			}
		}

		//翻转
		if ((h > 0 && !vida.facingRight) || (h < 0 && vida.facingRight))
			Flip();
	}

	//跳跃控制
	void JumpControll()
	{
		//跳跃
		if (vida.jump)
		{
			//跳跃音效
			SoundManager.GetInstance().PlaySoundEffect(SoundManager.Vida_Jump, transform.position,0.6f);

			GetComponent<Animator>().SetTrigger("Jump");
			body.velocity = new Vector2(body.velocity.x, 0);
			body.AddForce(new Vector2(0, vida.jumpForce));

			vida.jump = false;
		}

	}

	//冲撞控制
	void ChargeControll()
	{
		//冲撞
		if (vida.charge)
		{
			//冲撞音效
			SoundManager.GetInstance().PlaySoundEffect(SoundManager.Vida_Charge, transform.position);

			GetComponent<Animator>().SetTrigger("Charge");
			vida.charge = false;
			vida.chargeTimer = 0.0f;
			vida.inCharging = true;
			return;
		}
	}
}
