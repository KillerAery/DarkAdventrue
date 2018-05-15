using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : Biology
{
	Transform vidaTf;
	Rigidbody2D body;
	public float speed = 0.1f;
	Vector3 direction;
	// Use this for initialization
	void Start () {

		vidaTf = GameObject.FindGameObjectWithTag("Player").transform;

		body = GetComponent<Rigidbody2D>();

		var vidaPos = new Vector3(vidaTf.position.x, vidaTf.position.y + 0.4f, 0);
		direction = vidaPos - transform.position;
		direction = direction.normalized;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
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
		body.velocity = direction * speed;
	}

}
