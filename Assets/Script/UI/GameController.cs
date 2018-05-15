using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour {
    public int coinNum;
    public int maxCoinNum;
    public int failKillNum;
    public int maxFailNum;
    //计时统计
    public float gameTimer = 0.0f;

    public Text coinNumText;

    public void AddOneCoin()
    {
        coinNum++;
    }

    public void AddOneFailKill()
    {
        failKillNum++;
    }

    // Use this for initialization
    void Start () {
        coinNum = 0;
        failKillNum = 0;
     //   coinNumText = GameObject.FindWithTag("coinText").GetComponent<Text>();
    }
	

	// Update is called once per frame
	void Update () {
        //游戏计时器
        gameTimer += Time.deltaTime;
        ////更改UI显示 硬币数量
        //string numString = "X "+ coinNum.ToString();
        //coinNumText.text = numString;
    }

}
