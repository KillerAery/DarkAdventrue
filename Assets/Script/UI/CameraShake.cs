using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	// 震动标志位
	public bool isshakeCamera = false;

	// 震动幅度
	public float shakeLevel = 3f;
	// 震动时间
	public float setShakeTime = 0.2f;
	// 震动的FPS
	public float shakeFps = 45f;

	private float fps;
	private float shakeTime = 0.0f;
	private float frameTime = 0.0f;
	private float shakeDelta = 0.005f;
	private Camera selfCamera;

	private Rect changeRect;

	void Awake()
	{
		selfCamera = GetComponent<Camera>();
		changeRect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
	}

	// Use this for initialization
	void Start()
	{
		shakeTime = setShakeTime;
		fps = shakeFps;
		frameTime = 0.03f;
		shakeDelta = 0.005f;
	}

	// Update is called once per frame
	void Update()
	{
		if (isshakeCamera)
		{
			if (shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0)
				{
					changeRect.xMin = 0.0f;
					changeRect.yMin = 0.0f;
					selfCamera.rect = changeRect;
					isshakeCamera = false;
					shakeTime = setShakeTime;
					fps = shakeFps;
					frameTime = 0.03f;
					shakeDelta = 0.005f;
				}
				else
				{
					frameTime += Time.deltaTime;

					if (frameTime > 1.0 / fps)
					{
						frameTime = 0;
						changeRect.xMin = shakeDelta * (-1.0f + shakeLevel * Random.value);
						changeRect.yMin = shakeDelta * (-1.0f + shakeLevel * Random.value);
						selfCamera.rect = changeRect;
					}
				}
			}
		}
	}

	//只震动一下
	public void ShakeOnce()
	{
		Shake();
		Invoke("UnShake",1f);
	}

	//一直震动
	public void Shake()
	{
		isshakeCamera = true;
	}

	//停止震动
	public void UnShake()
	{
		isshakeCamera = false;
	}
}
