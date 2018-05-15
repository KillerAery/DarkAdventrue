using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBarView : MonoBehaviour {
	public GameObject bloodBarView;
	public Text bossNameText;
	public Slider slider;

	float nowPercent = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	public void ShowBloodBar(string bossName)
	{
		bloodBarView.SetActive(true);
		bossNameText.text = bossName;
    }

	public void SetBloodPercent(float percent)
	{
		//若没显示view，则无需操作
		if (!bloodBarView.activeSelf) return;

		SlowlyChangeBloodPercent(percent);
	}

	//缓慢减少血条
	void SlowlyChangeBloodPercent(float percent)
	{
		nowPercent = percent;
	}

	public void UnshowBloodBar()
	{
		bloodBarView.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if(nowPercent < slider.value)
		{
			slider.value = slider.value - 0.01f;
		}

	}
}
