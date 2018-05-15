using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//站立AI
public class Village1_AI : VillageBase_AI{

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//如果是玩家
		if (collision.gameObject.tag == "Player")
		{
			//聊骚
			RandomSpeak();
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		//如果是玩家
		if(collision.gameObject.tag == "Player")
		{

			//面向玩家
			if (collision.gameObject.transform.position.x > transform.position.x)
			{
				transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x),transform.localScale.y);
                speakView.transform.localScale = new Vector2(Mathf.Abs(speakView.transform.localScale.x),speakView.transform.localScale.y);
            }
			else
			{
				transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                speakView.transform.localScale = new Vector2(-Mathf.Abs(speakView.transform.localScale.x), speakView.transform.localScale.y);
            }
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
