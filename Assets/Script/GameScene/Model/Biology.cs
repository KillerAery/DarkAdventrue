using UnityEngine;
using System.Collections;

public class Biology : MonoBehaviour
{
	//死亡特效的对象
	public GameObject FailDie_ParticleEffect;
	// Use this for initialization
	void Start()
	{

	}

	public virtual void Die()
	{	
		if(FailDie_ParticleEffect != null)
		GameObject.Find("EffectManager").GetComponent<EffectManager>().PlayParticleEffect(FailDie_ParticleEffect, transform);
		//销毁自己
		GameObject.Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
