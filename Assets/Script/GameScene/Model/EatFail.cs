using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFail : Fail {

    // Use this for initialization
    void Start()
    {

    }

    //检测玩家是否碰到
    void CheckPlayer(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player") return;

        var vidaObject = coll.gameObject;
        var vida = vidaObject.GetComponent<Vida>();

        //如果玩家正处在冲撞状态
        if (vida.inCharging && ((vida.facingRight?1:-1) == GetComponent<Fail_AI>().direction))
        {
            Die();
        }
        else if(!vida.invincivle)
        {
            vida.Die();
        }
    }

    //碰撞时触发事件
    void OnCollisionStay2D(Collision2D coll)
    {
        CheckPlayer(coll);
    }

	//碰撞时触发事件
	void OnCollisionEnter2D(Collision2D coll)
	{
		CheckPlayer(coll);
	}

	// Update is called once per frame
	void Update()
    {

    }
}
