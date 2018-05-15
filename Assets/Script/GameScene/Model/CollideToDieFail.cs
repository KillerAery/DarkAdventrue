using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideToDieFail : Fail{

	// Use this for initialization
	void Start () {
		
	}

    //碰撞时触发事件
    void OnCollisionEnter2D(Collision2D coll)
    {   //如果碰到玩家
        if (coll.gameObject.tag == "Player")
        {
            var vida = coll.gameObject.GetComponent<Vida>();
            //如果玩家正处在冲撞状态
            if (vida.inCharging)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                vida.Die();
            }
        }
        //如果碰到别的物体，自己死亡
        else
        {
            Die();
        }
    }

	//碰撞时触发事件
	void OnCollisionStay2D(Collision2D coll)
	{   //如果碰到玩家
		if (coll.gameObject.tag == "Player")
		{
			var vida = coll.gameObject.GetComponent<Vida>();
			//如果玩家正处在冲撞状态
			if (vida.inCharging)
			{
				GameObject.Destroy(gameObject);
			}
			else
			{
				vida.Die();
			}
		}
		//如果碰到别的物体，自己死亡
		else
		{
			Die();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
