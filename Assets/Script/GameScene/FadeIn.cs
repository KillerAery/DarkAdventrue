using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public float FadeTime = 1.5f;
	bool ifFadeIn = false;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(1,1,1,0);
	}

	public void StartFadeIn() {
		ifFadeIn = true;
	}

	// Update is called once per frame
	void Update () {
		if (ifFadeIn)
		{
			timer += Time.deltaTime;
			if (timer < FadeTime && spriteRenderer.color.a <= 1)
			{
				spriteRenderer.color = new Color(1, 1, 1, timer / FadeTime);
			}
			else
			{
				ifFadeIn = false;
			}
		}

	}
}
