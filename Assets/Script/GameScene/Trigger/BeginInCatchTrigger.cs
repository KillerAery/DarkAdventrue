using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginInCatchTrigger : MonoBehaviour {
	public AudioClip catchBGM;
	public AudioSource audioSource;
	public CameraShake mainCamera;
	//毒圈
	public PoisonCircle poisonCircle;
	//地图上的怪物
	public GameObject failList;
	//结局触发点
	public GameObject endPoint;


	public Vida vida;
	// Use this for initialization
	void Start () {
		
	}

	public void StartCatch()
	{
		//镜头抖动
		mainCamera.Shake();

		//播放跑酷音乐
		audioSource.clip = catchBGM;
		audioSource.Play();

		//黑雾开始追赶vida
		poisonCircle.StartCatch();
		poisonCircle.ResetPosition();
		//vida获得二段跳
		vida.GetDoubleJumpSkill();
		//vida获得守护（图像特效）
		vida.ReceiveGuard_AfterBoss();

		//重新生成怪物
		Instantiate(failList);

		//结局触发点生成
		endPoint.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
