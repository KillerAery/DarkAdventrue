using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village2_AI : VillageBase_AI{
    public Transform[] toTurnBack = new Transform[2];
    Vector3[] posToTurnBack = new Vector3[2];

    public float walkSpeed = 1.0f;
    bool walkAble = true;

    public float stayTime = 2.0f;
    public float speakInterval = 8.0f;
    Rigidbody2D body;

    bool turnBackCheckable = true;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

        posToTurnBack[0] = toTurnBack[0].position;
        posToTurnBack[1] = toTurnBack[1].position;

        //循环聊骚
        InvokeRepeating("RandomSpeak", Random.Range(0,1)* speakInterval, speakInterval);

        //开始走路
        AllowWalk();
    }

    public void TurnBack()
    {
        walkAble = false;
        //不允许检查
        turnBackCheckable = false;
        //停下
        body.velocity = Vector3.zero;
        //停留一段时间再开始走
        Invoke("AllowWalk", stayTime);
    }

    public void AllowWalk()
    {
        walkAble = true;
        //转身
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        speakView.transform.localScale = new Vector2(-speakView.transform.localScale.x, speakView.transform.localScale.y);
        //过一小段短暂时间才开始检查，方便离开turnBack点
        Invoke("AllowCheckTurnBack", 0.1f);
    }

    //允许检查
    void AllowCheckTurnBack()
    {
        turnBackCheckable = true;
    }

    // Update is called once per frame
    void Update () {
        if (walkAble)
        {
            //如果碰到了 转头点，就回头
            if (turnBackCheckable&& (InTheRange(posToTurnBack[0])||InTheRange(posToTurnBack[1])))
            {
                TurnBack();
            }
            else
            {
                float direction = Mathf.Sign(transform.localScale.x);
                body.velocity = new Vector2(walkSpeed * direction, body.velocity.y);
				GetComponent<Animator>().SetFloat("Speed",walkSpeed * 0.8f);
			}
        }
	}

    bool InTheRange(Vector3 pos2)
    {
        Vector3 pos1 = transform.position;

        return 
            pos1.x < (pos2.x + 0.01f)
            && pos1.x > (pos2.x - 0.01f)
            && pos1.y < (pos2.y + 5f)
            && pos1.y > (pos2.y - 5f);
    }

}
