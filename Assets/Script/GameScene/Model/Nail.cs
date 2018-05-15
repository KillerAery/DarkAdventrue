using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Vida>().EatDamage();
        }
    }
}
