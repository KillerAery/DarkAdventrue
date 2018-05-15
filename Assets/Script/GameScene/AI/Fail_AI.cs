using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail_AI : MonoBehaviour
{
    public float speed = 1.0f;
    public int direction = 1;


    //回头
    void TurnBack()
    {
        direction = -direction;
        //精灵翻转
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //检测前进方向的地面是否踏空
    bool CheckGrounded()
    {

        //前方地面
        var leftPosition = new Vector2(transform.position.x + direction * 0.1f, transform.position.y);
        var leftGroundCheckPosition = new Vector2(leftPosition.x + direction * 0.1f, transform.position.y - 0.4f);
        bool forwardGrounded = Physics2D.Linecast(leftPosition, leftGroundCheckPosition, 1 << LayerMask.NameToLayer("Ground"));


        return forwardGrounded;
    }

    bool CheckWalled()
    {
        var wallCheckPosition = new Vector2(transform.position.x + direction * 0.5f, transform.position.y);
        //如果是墙面或者设置好的回头点，则回头
        bool walled = Physics2D.Linecast(transform.position, wallCheckPosition, 1 << LayerMask.NameToLayer("Ground"))
            || Physics2D.Linecast(transform.position, wallCheckPosition, 1 << LayerMask.NameToLayer("FailToTurnBack"));

        return walled;
    }

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {


        //如果没有碰到地面，即踏空的话，则回头
        if (!CheckGrounded()||CheckWalled())
        {
            TurnBack();
        }

        //移动
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

}
