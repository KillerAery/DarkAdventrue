using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject GameStartPrefab;
    public GameObject Menu;
    public GameObject GameOver;
    public GameObject ResurrectionSelection;//复活选择
    public GameObject ClearLevelView;
    static public bool hasScene;
    // Use this for initialization
    void Start () {
        hasScene = false;
        GameSceneInformation.GetInstance();//初始化
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart()
    {
        if (!hasScene)
        {
            Instantiate(GameStartPrefab, Vector3.zero, transform.rotation);
            Debug.Log(hasScene);
        } 
        hasScene = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowMenu()
    {
        Menu.SetActive(true);
    }
    public void ShowGameover()
    {
        GameOver.SetActive(true);
    }


    //显示复活选择界面
    //public void ShowSelection()
    //{
    //    ResurrectionSelection.SetActive(true);
    //}

    //返回主菜单

    public void LoadGameScene()
    {   
        SceneManager.LoadScene("GameScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadStartSceneAndEnterSelectLayer()
    {
        LoadStartScene();
    }

    public void LoadGameSceneNextLevel()
    {
        GameSceneInformation.GetInstance().LevelName = GameSceneInformation.GetInstance().NextLevelName;
        LoadGameScene();
    }

    public void PauseGameScene(bool pause)
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

}
