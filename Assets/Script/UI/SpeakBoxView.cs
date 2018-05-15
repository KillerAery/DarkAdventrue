using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakBoxView : MonoBehaviour {
    public float speed = 1.0f;
    public TextMesh speakText;
	// Use this for initialization
	void Start () {
		
	}

    public void Speak(string word)
    {
        speakText.gameObject.SetActive(true);
        speakText.text = word;
    }

    public void Unspeak()
    {
        speakText.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
