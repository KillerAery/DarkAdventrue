using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRMoveGround : MonoBehaviour {
    public float Speed = 1f;
    public bool FacingRight = true;
    public float IrNowTime = 0.0f;
    public float MaxTime = 2.0f;
    Rigidbody2D body;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        body.velocity = new Vector2((FacingRight? 1 : -1) * Speed , 0);

        if (IrNowTime >= MaxTime)
        {
            FacingRight = !FacingRight;
            IrNowTime = 0f;
        }

        IrNowTime += Time.deltaTime;
    }
}
