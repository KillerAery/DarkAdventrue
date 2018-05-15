using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPC_DEMO_UpDown : MonoBehaviour
{
    private Vector3 startPos;
    public float height;
    public float speed;

    void Start()
    {
        startPos = transform.position;
    }

	// Update is called once per frame
	void Update ()
	{
	    transform.position = startPos + Vector3.up * height * Mathf.Sin(Time.time * speed);
	}
}
