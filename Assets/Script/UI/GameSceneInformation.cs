using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//单例类
public class GameSceneInformation{

    private static GameSceneInformation sceneInformation = null;

    private static GameSceneInformation Create()
    {
        var information = new GameSceneInformation();
        if (information==null || !information.Init()){information = null;}
        return information;
    }

    public static GameSceneInformation GetInstance()
    {
        if (sceneInformation == null) {
            sceneInformation = Create();
        } 
        return sceneInformation;
    }

    /*-------------------------------------具体实现---------------------------*/

    //默认初始关卡1-1
    public string LevelName = "1-1";
    public string NextLevelName = "1-1";
    //默认初始蛋 咸鱼蛋
    public string DanName = Tags.XianyuDan;


    // Use this for initialization  
    bool Init()
    {
        InitInformation();
        return true;
    }
    //允许使用第一关和咸鱼蛋
    void InitInformation()
    {
        PlayerPrefs.SetInt("1-1", 1);
        PlayerPrefs.SetInt("1-2", 0);
        PlayerPrefs.SetInt("1-3", 0);
        PlayerPrefs.SetInt("2-1", 0);
        PlayerPrefs.SetInt("2-2", 0);
        PlayerPrefs.SetInt("2-3", 0);

        PlayerPrefs.SetInt(Tags.XianyuDan, 1);
        PlayerPrefs.SetInt(Tags.YingjianDan, 0);
        PlayerPrefs.SetInt(Tags.ChanpinDan, 0);
        PlayerPrefs.SetInt(Tags.MeigongDan, 0);
        PlayerPrefs.SetInt(Tags.RuanjianDan, 0);

        PlayerPrefs.SetInt("UnknowEggNum", 3);
    }

    public void SetDanName(string danname)
    {
        DanName = danname;
    }

    public void SetLevelName(string levelname)
    {
        LevelName = levelname;
    }
}
