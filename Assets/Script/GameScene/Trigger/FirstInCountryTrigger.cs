using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstInCountryTrigger : MonoBehaviour {

	public Camera mainCamera;
	public VidaController vidaController;
	public Animator animator;
	public GameObject UI;
	public AudioSource audioSource;
	public AudioClip FirstInCountryBGM;

	// Use this for initialization
	void Start () {

	}

	public void FirstInCountry()
	{
		//显示LOGO
		animator.Play("Logo");
		//玩家暂时失去控制
		vidaController.StopControll();
		//播放BGM
		audioSource.clip = FirstInCountryBGM;
		audioSource.Play();

		//UI隐藏
		UI.SetActive(false);

		//相机开始移动
		mainCamera.GetComponent<CPC_CameraPath>().PlayPath(15.0f);
		//15秒内变大1.7倍
		mainCamera.GetComponent<CameraScale>().StartScale(1.7f,15.0f);
		//15秒后恢复
		Invoke("Resume", 15.0f);
	}

	void Resume()
	{
		vidaController.ResumeControll();
		//UI恢复
		UI.SetActive(true);

		GameObject.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
