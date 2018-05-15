using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : Biology {

    // Use this for initialization
    void Start () {
		
	}

	public override void Die()
	{
		//死亡音效
		SoundManager.GetInstance().PlaySoundEffect(SoundManager.Fail_Die,0.6f);
        //怪物消灭数+1
       GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddOneFailKill();

        base.Die();
	}

    //检测玩家是否碰到
    void CheckPlayer(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player") return;

        var vida = coll.gameObject.GetComponent<Vida>();

        //如果玩家正处在冲撞状态
        if (vida.inCharging)
        {
            Die();
        }
        else
        {
            vida.EatDamage();
        }
    }

    //碰撞时触发事件
    void OnCollisionStay2D(Collision2D coll)
    {
        CheckPlayer(coll);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		CheckPlayer(coll);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
