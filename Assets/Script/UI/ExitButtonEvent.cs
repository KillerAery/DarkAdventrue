using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonEvent : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //暴露退出游戏函数给按钮事件使用
    public void ExitGame()
    {
        Application.Quit();
    }
}
