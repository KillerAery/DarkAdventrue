using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiansManager : MonoBehaviour {
	public List<GameObject> guardians;
	public float OutcomeTime = 8f;
	public Animator nvzhuAnimator;

	// Use this for initialization
	void Start () {
		foreach(var i in guardians)
		{
			i.SetActive(false);
		}
	}
	
	public void StartGuradiansManage()
	{
		int i;
		do
		{
			i = Random.Range(0, guardians.Count);
		} while (guardians[i].activeSelf);

		guardians[i].SetActive(true);
		guardians[i].GetComponent<Guradian>().Show();

		//女主施法动画
		nvzhuAnimator.SetTrigger("Guard");

		Invoke("StartGuradiansManage", OutcomeTime);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
