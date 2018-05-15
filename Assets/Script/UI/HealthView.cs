using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthView : MonoBehaviour {
	public GameObject[] healthImages = new GameObject[6];
	// Use this for initialization
	void Start () {
		
	}
	
	public void SetHealthImage(int health)
	{
		//生命范围监测  只可能0~6
		if (health > 6) { health = 6; }
		else if(health < 0) { health = 0; }

		//显示当前生命数量的图像
		for(int i = 0; i < health; ++i)
		{
			healthImages[i].SetActive(true);
		}
		//隐藏多余数量的图像
		for(int i = health; i < 6; ++i)
		{
			healthImages[i].SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
