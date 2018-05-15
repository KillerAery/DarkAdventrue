using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCDView : MonoBehaviour {
    public Vida vida;
    //冲撞CD图标
    CanvasRenderer render;
	// Use this for initialization
	void Start () {
        render = GetComponent<CanvasRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //若没有vida则退出
        if (vida == null) {
            return;
        }

        float cd = vida.chargeColdTime;
        float timer = vida.chargeTimer;
       
		//cd时间已到达，可以使用冲撞技能，则图标显示
		if (timer >= cd)
			render.SetAlpha(1.0f);
		//否则图标隐藏
		else
			render.SetAlpha(0);
	}
}
