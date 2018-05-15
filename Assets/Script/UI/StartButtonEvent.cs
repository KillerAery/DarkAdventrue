using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonEvent : MonoBehaviour {
    public GameObject startView;

	// Use this for initialization
	void Start ()
    {
        GameSceneInformation.GetInstance();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //暴露开始游戏函数给按钮事件使用
    public void StartGame()
    {
        startView.SetActive(false);
    }
}
