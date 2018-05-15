using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailBoss : Biology {
	public float health = 100.0f;
    public BloodBarView bloodBarView;
	public Heroine_AI heroinai;
    public string bossName = "阿史娜莎碧";

	public CameraShake cameraShake;

	// Use this for initialization
	void Start () {
		bloodBarView = GameObject.Find("BossBloodBar").GetComponent<BloodBarView>();
        bloodBarView.ShowBloodBar(bossName);

		heroinai = GameObject.Find("Heroine_BOSS").GetComponent<Heroine_AI>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void LoseHealth(float loseValue)
    {
        health -= loseValue;
        Debug.Log("health:" + health);
        bloodBarView.SetBloodPercent(health / 100f);

		//收到伤害时的音效
		SoundManager.GetInstance().PlaySoundEffect("BossEatDamage",0.6f);

        if (health <= 0)
            Die();
		
    }

    public new void Die()
    {
		heroinai.AfterBossTrigger();
		bloodBarView.UnshowBloodBar();
		base.Die();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//速度大于5f时，镜头抖动一下
		if (collision.relativeVelocity.magnitude > 5f)
		{

			if(collision.gameObject.tag == "Player")
			{
				var vida = collision.gameObject.GetComponent<Vida>();
				//如果没有守护，则boss毫不撼动
				if (!vida.guardian)
					return;
			}
			cameraShake.ShakeOnce();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			var vida = collision.gameObject.GetComponent<Vida>();

			if (vida.guardian)
			{

				if (vida.inCharging)
				{
					LoseHealth(15);
					vida.LoseGuard();
				}
			}
			else
			{
				vida.EatDamage();
			}

		}

	}
}
