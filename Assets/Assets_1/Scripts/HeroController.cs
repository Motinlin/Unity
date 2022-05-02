using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float MoveForce = 100.0f;
    public float MaxSpeed = 5;
    public Rigidbody2D HeroBody;
    public bool bFaceRight = true;//人物是否朝右,游戏开始时人物默认朝右
    public bool bJump = false;//一开始在空中,不能跳
    public float JumpForce = 100;//弹跳力
    private Transform mGroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;//60fps
        HeroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {   Vector2 position = transform.position;
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        /*通过改变位置实现移动
        position.x += 8f * hor * Time.deltaTime;
        position.y += 8f * ver * Time.deltaTime;
         deltaTime代表渲染一帧所需要的时间
         * 在固定了运行帧数之后，才能保证在所有机器上移动的速度一样
         * 在六十帧的情况下，即每帧移动1/12个单位
         * 每秒移动5个单位
        transform.position = position;
        */
        //将改变后的position赋值给transform里的position
        //Debug.Log(hor);//显示hor的值
        //GetComponent<组件名>();
        if (Mathf.Abs(HeroBody.velocity.x) < MaxSpeed)
            //未达到最大速度，施加力加速
        {
            HeroBody.AddForce(Vector2.right * hor * MoveForce);
            //Debug.Log(hor);
        }

        if (Mathf.Abs(HeroBody.velocity.x) > 5)
            //已达到最大速度
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed,
                                            HeroBody.velocity.y);
            //更新Hero的线速度(x,y)
        }
        if (hor > 0 && !bFaceRight)
        {
            flip();
        }
        else if (hor < 0 && bFaceRight)
        {
            flip();
        }
        if (Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            //在地面上
        {
            if (Input.GetButtonDown("Jump"))//按下了跳跃键
            {
                bJump = true;
            }
        }
            
    }
    void flip()//转身
    {
        Vector3 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
        bFaceRight = !bFaceRight;//每转一次bFaceRight变一次
    }
    private void FixedUpdate()
    /*固定更新
     * 不适合角色移动
     */
    {
        if (bJump)
        {
            HeroBody.AddForce(Vector2.up * JumpForce);
            bJump = false;
        }
    }
}
