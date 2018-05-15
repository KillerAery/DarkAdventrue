using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageBase_AI : MonoBehaviour {
    //骚话列表
    public List<string> words;
    public SpeakBoxView speakView;

    // Use this for initialization
    void Start()
    {

    }

    //随机聊骚
    protected void RandomSpeak()
    {
        if (words.Count > 0)
        {
            string wordToSpeak = words[Random.Range(0, words.Count)];
            speakView.Speak(wordToSpeak);
            Invoke("UnSpeak", 3.0f);
        }

    }

    protected void UnSpeak()
    {
        speakView.Unspeak();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
