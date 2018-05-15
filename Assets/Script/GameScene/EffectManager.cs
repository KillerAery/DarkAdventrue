using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
    public void PlayParticleEffect(GameObject _effect,Transform t)
    {
        //播放死亡特效
        var effect = Instantiate(_effect,t.position,t.rotation,transform);
        effect.GetComponent<Fail_Die_ParticleEffect>().PlayEffect();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
