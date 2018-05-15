using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDMoveGround : MonoBehaviour {
    public float Speed = 10f;
    public bool FacingUp = true;
    public float MaxTime = 2.0f;
    public float UdNowTime = 0.0f;
    Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0,(FacingUp ? 1 : -1) * Speed);

        if (UdNowTime >= MaxTime)
        {
            FacingUp = !FacingUp;
            UdNowTime = 0f;

        }
		UdNowTime += Time.deltaTime;
    }
}
