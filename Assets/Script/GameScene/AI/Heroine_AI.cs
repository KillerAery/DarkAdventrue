using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroine_AI : MonoBehaviour {
	//骚话列表
	public string[] wordsBeforeBattle;
	public string[] wordsAfterBattle;
	public SpeakBoxView speakView;
	//辅助骚话一句句说
	int index = 0;

	//说完话要触发的脚本
	public BeginInCatchTrigger catchBegin;
	public BeginInBossTrigger bossBegin;

	//关闭BOSS区域的墙， 防止玩家跳出去
	public GameObject walls;

	public Camera mainCamera;

	public GuardiansManager guardiansManager;
	//需要删除的钉子，方便跑酷
	public GameObject nailToDelete;

	public AudioSource audioSource;


	// Use this for initialization
	void Start() {

	}

	public void BeforeBossTrigger()
	{

		mainCamera.GetComponent<Animator>().enabled = true;
		mainCamera.GetComponent<CamerTrack>().UnableTrack();
		mainCamera.GetComponent<Animator>().Play("Camera_BeforeBoss");

		index = 0;
		walls.SetActive(true);

		SpeakBeforeBattle();

	}

	//开始Boss
	void BeforeBoss()
	{
		speakView.Unspeak();

		mainCamera.GetComponent<CamerTrack>().EnableTrack();
		mainCamera.GetComponent<Animator>().enabled = false;

		bossBegin.StartBoss();
	}

	//一直说话，说完话才执行  boss战
	void SpeakBeforeBattle()
	{
		if (wordsBeforeBattle.Length <= index)
		{
			BeforeBoss();
			return;
		}
		
		string words = wordsBeforeBattle[index];
		index++;
		speakView.Speak(words);

		Invoke("SpeakBeforeBattle", 4.0f);
	}



	//进入跑酷前
	public void AfterBossTrigger()
	{
		index = 0;
		//镜头移动
		mainCamera.GetComponent<Animator>().enabled = true;
		mainCamera.GetComponent<Animator>().StopPlayback();
		mainCamera.GetComponent<CamerTrack>().UnableTrack();
		mainCamera.GetComponent<Animator>().Play("Camera_AfterBoss");
		//停止刷出守护
		GameObject.Destroy(guardiansManager.gameObject);
		GameObject.Destroy(nailToDelete);
		//停止音乐
		audioSource.Stop();

		SpeakAfterBattle();
	}


	//一直说话，说完话才结束 boss战 进入跑酷
	void SpeakAfterBattle()
	{
		if (wordsAfterBattle.Length <= index)
		{
			AfterBoss();
			return;
		}

		string words = wordsAfterBattle[index];
		index++;
		speakView.Speak(words);

		Invoke("SpeakAfterBattle", 4.0f);
	}


	//进入跑酷
	void AfterBoss()
	{

		speakView.Unspeak();
		//恢复镜头
		mainCamera.GetComponent<CamerTrack>().EnableTrack();
		mainCamera.GetComponent<Animator>().enabled = false;

		walls.SetActive(false);
		catchBegin.StartCatch();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
