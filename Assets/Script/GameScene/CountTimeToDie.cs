using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTimeToDie : MonoBehaviour {
	public float dieTime = 0.5f; 
	// Use this for initialization
	void Start () {
		
	}

	public void Die()
	{
		gameObject.SetActive(false);
	}

	public void StartCountToDie()
	{
		Invoke("Die", dieTime);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
