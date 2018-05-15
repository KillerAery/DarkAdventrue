using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guradian : MonoBehaviour {
	public List<GameObject> m_roads;

	public float startTime = 2.0f;

	public float comeOutTime = 0.5f;
	float timer_comeOutTime = 0.0f;

	int roadIndex = 0;

	bool showable = false;
	// Use this for initialization
	void Start (){
	}

	//守护显现
	public void Show()
	{
		showable = true;
		timer_comeOutTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!showable) return;

		timer_comeOutTime += Time.deltaTime;
		//一条条路显现
		if(m_roads.Count > roadIndex && timer_comeOutTime >= comeOutTime)
		{
			if (roadIndex == 1 && timer_comeOutTime <= startTime)
			{
				return;
			}
			m_roads[roadIndex].SetActive(true);
			m_roads[roadIndex].GetComponent<CountTimeToDie>().StartCountToDie();
			roadIndex++;
			timer_comeOutTime = 0.0f;
		}
		else if(roadIndex == m_roads.Count && timer_comeOutTime > 3.0f)
		{
			Unshow();
		}

	}

	public void Unshow()
	{
		showable = false;
		roadIndex = 0;
		timer_comeOutTime = 0.0f;
		gameObject.SetActive(false);
	}
}
