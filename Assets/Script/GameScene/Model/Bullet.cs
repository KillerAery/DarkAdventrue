using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Biology{
    public float speed = 5.0f;

    protected Rigidbody2D body;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
		//生命周期只有8s
		Invoke("Die", 8f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Player")
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

        GameObject.Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
        float direction = transform.localScale.x;
        body.velocity = new Vector3(speed*direction,0,0);
    }

}
