using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail_Die_ParticleEffect : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
	
    void Die()
    {
        GameObject.Destroy(gameObject);
    }

    public void PlayEffect()
    {
        GetComponent<ParticleSystem>().Play();
        //N秒后播放完特效，摧毁自己。
        Invoke("Die", 2.0f);
    }


	// Update is called once per frame
	void Update () {

	}


}
