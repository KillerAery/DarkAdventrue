using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassGround : MonoBehaviour {
    private GameObject player;
    private GameObject ground;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        foreach (Transform child in transform)
        {
            if(child.gameObject.name == "Collision_Default")
            {
                ground = child.gameObject;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        //玩家 高于 平台时
        if (player.transform.position.y >= transform.position.y +0.25)
        {
            //允许玩家和平台碰撞
            ground.SetActive(true);
        }
        else
        {
            ground.SetActive(false);
        }
    }
}
