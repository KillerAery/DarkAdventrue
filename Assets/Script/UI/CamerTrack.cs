using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerTrack : MonoBehaviour {

    public float xMargin= 1f;
    public float yMargin= 1f;
    public float xSmooth= 8f;
    public float ySmooth= 8f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    private Transform player;
	public bool Track = false;

    public void EnableTrack()
    {
		Track = true;
    }
	public void UnableTrack()
	{
		Track = false;
	}


	bool CheckXmargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYmargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
      
    }

    void TrackPlayer()
    {
        if (Track)
        {
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            if (CheckXmargin())
                targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
            if (CheckYmargin())
                targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
       
    }


    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        TrackPlayer();
    }
}
