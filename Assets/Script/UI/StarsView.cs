using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsView : MonoBehaviour {
    public GameObject[] stars = new GameObject[3];
    public GameObject particleEffect;
    int starsNum = 0;
    int showingNum = 0;

    public void Run(int n)
    {   
        //星星数量限定
        if (n <= 0) n = 0;
        else if (n >= 3) n = 3;

        starsNum = n;

        Invoke("ShowStar", 0.2f);
    }

    void ShowStar()
    {
        if (starsNum <= showingNum)
            return;
        //显示星星
        stars[showingNum].SetActive(true);
        //放出星星特效
        var particle = Instantiate(particleEffect, stars[showingNum].transform);
        particle.GetComponent<ParticleSystem>().Play();

        showingNum++;
        Invoke("ShowStar", 0.6f);
    }


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
