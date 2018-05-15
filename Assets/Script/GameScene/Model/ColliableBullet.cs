using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliableBullet : Biology
{

	// Use this for initialization
	void Start()
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        //如果还没击中，且碰到了玩家
        if (collision.gameObject.tag == "Player")
        {
			
            Vida vida = collision.gameObject.GetComponent<Vida>();

			if (vida.invincivle || vida.inCharging)
			{
				//donothing
			}
			else if (vida.guardian)
			{
				vida.LoseGuard();
			}
			else
			{
				vida.EatDamage();
			}

		}


        Die();

    }


	// Update is called once per frame
	void Update()
	{
		//if (!ifHit)
		//{
		//	float direction = transform.localScale.x;
		//	body.velocity = new Vector3(speed * direction, 0, 0);
		//}
	}

	////被踩住，进入第二状态
	//void Hit()
	//{
	//	ifHit = true;
	//	//恢复正常重力
	//	body.gravityScale = 1.0f;
	//	body.velocity = Vector3.zero;
	//}
}
