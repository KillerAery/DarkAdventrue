using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {
    //事件列表
    public UnityEvent[] events = new UnityEvent[1];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Die()
	{
		GameObject.Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.gameObject.tag == "Player")
        {
            //触发则调用事件列表
            foreach (UnityEvent oneEvent in events)
            {
                oneEvent.Invoke();
            }
        }

    }
}
