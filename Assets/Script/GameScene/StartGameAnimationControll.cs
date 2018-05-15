using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameAnimationControll : MonoBehaviour {
	public bool ifStart = false;
	float timer = 0.0f;
	bool faillBossComeOut = false;
	public VidaController vidaController;
	public Camera maincamera;
	public GameObject HUD;

	public GameObject guradian;

	public void StartAnimation()
	{
		ifStart = true;
		maincamera.GetComponent<Animator>().enabled = true;
		maincamera.GetComponent<Animator>().Play("Camera_Start");
		maincamera.GetComponent<CamerTrack>().UnableTrack();
	}

	// Use this for initialization
	void Start () {
		maincamera.GetComponent<CamerTrack>().UnableTrack();
	}

	//恢复正常游戏
	void ResumeGame()
	{
		//允许控制
		vidaController.ResumeControll();
		//停止相机动画
		maincamera.GetComponent<Animator>().enabled = false;
		maincamera.GetComponent<CamerTrack>().EnableTrack();
		//加入HUD
		HUD.SetActive(true);

		GameObject.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (ifStart)
		{
			timer += Time.deltaTime;


			if(!faillBossComeOut && timer >= 3.0f)
			{
				faillBossComeOut = true;
				GetComponent<Animator>().Play("Start");
			}
			else if (timer >= 4.9f)
			{   
				 //禁用动画
				GetComponent<Animator>().enabled = false;
				//守护消失
				guradian.SetActive(false);
				if (timer >= 10f)
				{
					ResumeGame();
				}
			}
		}
	}
}
