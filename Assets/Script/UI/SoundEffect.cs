using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public List<AudioClip> soundEffects;

	// Use this for initialization
	void Start () {

	}

	public void Play(string EffectName, Vector3 position,float volume)
	{

		foreach (var sound in soundEffects)
		{
			if (sound.name == EffectName)
			{
				AudioSource.PlayClipAtPoint(sound,position,volume);
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
