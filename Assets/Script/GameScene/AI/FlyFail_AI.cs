using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFail_AI : MonoBehaviour {
    public float speedX = 0.0f;
    public float speedY = 0.0f;
    bool alreadyFly = false;
    Rigidbody2D body;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (alreadyFly)
            body.velocity = new Vector2(speedX, speedY);
    }

    //往上飞
    public void Fly()
    {
        alreadyFly = true;
    }
}
