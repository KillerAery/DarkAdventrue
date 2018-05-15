using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginInBossTrigger : MonoBehaviour {
	public GameObject boss;
	public GuardiansManager guardiansManager;
	public CameraShake cameraShake;
	public AudioClip bossBGM;
	public AudioSource audioSource;
	//地图上的怪物
	public GameObject failList;

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartBoss()
	{
		//清理怪物，以免BOSS战卡顿
		GameObject.Destroy(failList);
		//生成boss
		var bossCreated = Instantiate(boss);
		bossCreated.GetComponent<FailBoss>().cameraShake = cameraShake;
		//开始刷出守护祝福
		guardiansManager.StartGuradiansManage();
		//boss BGM
		audioSource.clip = bossBGM;
		audioSource.Play();

	}

	// Update is called once per frame
	void Update () {
		
	}
}
