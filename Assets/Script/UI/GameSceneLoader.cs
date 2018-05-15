using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneLoader : MonoBehaviour {

    public GameObject[] levels = new GameObject[6];
    public GameObject[] vidas = new GameObject[5];
    //调试时在组件页面修改该值，可不加载场景
    public bool DebugMode = true;

    public ChargeCDView chargeCDview;

    GameSceneInformation information;
    GameController gameController;

    GameObject nowLevel;
    GameObject nowVida;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        CleanUpLevelAndVida();
        LoadLevelInformation();
        LoadUIInformation();
    }
	
    void LoadLevelInformation()
    {
        if (DebugMode) return;

        information = GameSceneInformation.GetInstance();
        var levelNameToLoad = information.LevelName;
        var danNameToLoad = information.DanName;
        //根据载入信息 初始化相应的关卡 
        foreach (var level in levels)
        {
            if(level.name == levelNameToLoad)
            {
                nowLevel = Instantiate(level,transform);
                break;
            }
        }
        //根据载入信息 初始化相应的蛋
        foreach (var vida in vidas)
        {
            if (vida.name == danNameToLoad)
            {   
                nowVida = Instantiate(vida, transform);
                break;
            }
        }


        //加载硬币数量
        var coins = GameObject.FindGameObjectsWithTag("coin");
        gameController.maxCoinNum = coins.Length;
        //加载怪物数量
        var fails = GameObject.FindObjectsOfType<Fail>();
        gameController.maxFailNum = fails.Length;
    }

    void LoadUIInformation()
    {
        //给冲撞冷却显示UI 绑上 vida
        chargeCDview.vida = nowVida.GetComponent<Vida>();
    }

    
    void CleanUpLevelAndVida()
    {
        chargeCDview.vida = null;
        GameObject.Destroy(nowLevel);
        GameObject.Destroy(nowVida);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
