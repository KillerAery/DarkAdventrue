using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour {

    public float speed = 0.02f;
    public int direction = 1;
    public float maxX = 10.0f;
    public float minX = -10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       Transform transform = GetComponent<Transform>();

        var targetPosition = new Vector3(transform.position.x + direction * speed , transform.position.y);
        if (direction>0 && targetPosition.x > maxX) { targetPosition.x = minX; }
        if (direction < 0 && targetPosition.x < minX) { targetPosition.x = maxX; }

        transform.SetPositionAndRotation(targetPosition , transform.rotation);
    }
}
