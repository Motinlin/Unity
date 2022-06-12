using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerctr : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveForce = 200.0f;//对刚体物体持续施加一个力
    public float MaxSpeed = 5;//最大速度
    public Rigidbody2D HeroBody;
    public bool bFaceRight = true;/*判断角色朝向*/
    /*跳跃*/
    public bool bJump = false;
    public float JumpForce = 100;
    private Transform mGroundCheck;
    Animator anim;
    void Start()
    {
        HeroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //anim.SetTrigger("shooting");
        float h = Input.GetAxis("Horizontal");
        if(Mathf.Abs(HeroBody.velocity.x) < MaxSpeed)
        {
            HeroBody.AddForce(Vector2.right * h * MoveForce);
        }

        if (Mathf.Abs(HeroBody.velocity.x) > 5)
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed, HeroBody.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(h));/*把h的值赋给Speed*/
        /* 转身  判断角色朝向*/
        if (h > 0 && !bFaceRight)
        {
            flip();
        }
        else if(h < 0 && bFaceRight)
        {
            flip();
        }
        /*跳跃*/
        /*射线检测*/
        if (Physics2D.Linecast(transform.position, mGroundCheck.position,
                                 1 << LayerMask.NameToLayer("Ground")))
        {
            if(Input.GetButtonDown("Jump"))
            {
                bJump = true;/*can jump*/
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("shooting");
        }
    }
    /*转身函数*/
    private void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;

    }
    private void FixedUpdate()
    {
        if (bJump)
        {
            HeroBody.AddForce(Vector2.up * JumpForce);
            bJump = false;
            anim.SetTrigger("jump");
        }

    }
}
/*lerp 函数，插值函数，从一个值到另一个值
 血条，支点调整
*/