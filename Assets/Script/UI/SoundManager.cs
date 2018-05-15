using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager {

	private static SoundManager soundManager = null;

	private static SoundManager Create()
	{
		var soundManager = new SoundManager();
		if (soundManager == null || !soundManager.Init()) { soundManager = null; }
		return soundManager;
	}

	public static SoundManager GetInstance()
	{
		if (soundManager == null)
		{
			soundManager = Create();
		}
		return soundManager;
	}

	//-----------------------------单例类------------------
	public static string Coin = "Coin";
	public static string Vida_Jump = "Vida_Jump";
	public static string Vida_Charge = "Vida_Charge";
	public static string Vida_Die = "Vida_Die";
	public static string Fail_Die = "Fail_Die";


	SoundEffect soundEffectList;

	// Use this for initialization
	public bool Init(){
		soundEffectList = GameObject.Find("SoundEffect").GetComponent<SoundEffect>();
		return true;
	}
	
	public void PlaySoundEffect(string EffectName ,Vector3 position ,float volume = 1.0f)
	{
		soundEffectList.Play(EffectName,position,volume);
	}


	public void PlaySoundEffect(string EffectName, float volume = 1.0f)
	{
		PlaySoundEffect(EffectName,Vector3.zero,volume);
	}


}
