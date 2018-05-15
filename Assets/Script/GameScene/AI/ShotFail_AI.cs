using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFail_AI : MonoBehaviour {
    public float shootInterval = 2.3f;//射击间隔
    public GameObject bulletPerfab;
    public int direction = 1;
    private float timer = 0.0f;
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if(timer >= shootInterval)
        {
            timer = 0.0f;

            float facingDirection = -transform.localScale.x * direction;

            Vector3 pos = transform.position;
            pos.x = pos.x + 0.6f * facingDirection;

            var bulletObject = Instantiate(bulletPerfab,pos,transform.rotation, transform);
            
            Vector3 scale = bulletObject.transform.localScale;
            scale.x = facingDirection;
            bulletObject.transform.localScale = scale;


        }

    }
}
