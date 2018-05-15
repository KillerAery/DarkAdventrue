using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCircle : MonoBehaviour {
	public float maxOffset = 28.49f;
	public float catchTime= 3.5f;
	public bool catching = false;
	Vida vida;

	// Use this for initialization
	void Start () {
		vida = GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>();
	}

	public void ResetPosition()
	{
		transform.position = new Vector2(vida.transform.position.x + maxOffset, transform.position.y);
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			vida.EatDamage();
		}
	}

	public void StartCatch()
	{
		catching = true;
	}

	public void EndCatch()
	{
		catching = false;
		GameObject.Destroy(gameObject);
	}

	private void FixedUpdate()
	{
		




	}

	// Update is called once per frame
	void Update () {
		if (catching)
		{
			if (vida.transform.position.x < transform.position.x - maxOffset)
			{
				ResetPosition();
			}
			else
			{
				float DisToMove = Time.deltaTime / catchTime * maxOffset;
				transform.position = new Vector2(transform.position.x - DisToMove, transform.position.y);
			}

		}
	}
}
