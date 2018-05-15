using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyNail : MonoBehaviour {
    public float Speed = 1f;
    Rigidbody2D rb2D;
    Transform vidaTransform;
    Vida player;
    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        vidaTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Vida>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        //若vida的位置在上方则 触发
        if (CheckOverHead())
        {
            rb2D.velocity = new Vector2(0, Speed);
            Invoke("DieInSeconds",10.0f);
        }
    }

    bool CheckOverHead()
    {
        var vidaPos = vidaTransform.position;
        var Pos = transform.position;

        return
            vidaPos.x > Pos.x - 0.5f &&
            vidaPos.x < Pos.x + 0.5f &&
            vidaPos.y > Pos.y &&
            vidaPos.y < Pos.y + 2.0f;
    }

    void DieInSeconds()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //碰到玩家,玩家死亡
        if (collision.gameObject.tag == "Player")
        {
            player.EatDamage();
            GameObject.Destroy(gameObject);
            return;
        }
    }

}
