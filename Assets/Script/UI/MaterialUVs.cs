using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialUVs : MonoBehaviour {
	public float moveSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().material.mainTextureOffset += new Vector2(Time.deltaTime * moveSpeed * 0.02f, 0);
	}
}
