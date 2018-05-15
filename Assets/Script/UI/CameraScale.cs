using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour {
	Camera mainCamera;
	//是否正在缩放相机
	bool ifScalingCamera = false;
	//正常相机尺寸
	float normalCameraSize;
	float nowScale = 1.0f;
	public float targetScale = 1.7f;
	public float targetTime = 15f;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
		//记录原始尺寸
		normalCameraSize = mainCamera.orthographicSize;
	}

	public void StartScale(float scale,float time)
	{
		targetScale = scale;
		targetTime = time;
		ifScalingCamera = true;
		Invoke("Resume",targetTime);
	}

	void Resume()
	{
		mainCamera.orthographicSize = normalCameraSize;
		ifScalingCamera = false;
	}

	// Update is called once per frame
	void Update () {
		if (ifScalingCamera && nowScale <= targetScale)
		{
			mainCamera.orthographicSize = normalCameraSize * nowScale;
			nowScale += (1.0f / targetTime * Time.deltaTime);
		}
	}
}
