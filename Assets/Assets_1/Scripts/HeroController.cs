using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float MoveForce = 100.0f;
    public float MaxSpeed = 5;
    public Rigidbody2D HeroBody;
    public bool bFaceRight = true;//�����Ƿ���,��Ϸ��ʼʱ����Ĭ�ϳ���
    public bool bJump = false;//һ��ʼ�ڿ���,������
    public float JumpForce = 100;//������
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
        /*ͨ���ı�λ��ʵ���ƶ�
        position.x += 8f * hor * Time.deltaTime;
        position.y += 8f * ver * Time.deltaTime;
         deltaTime������Ⱦһ֡����Ҫ��ʱ��
         * �ڹ̶�������֡��֮�󣬲��ܱ�֤�����л������ƶ����ٶ�һ��
         * ����ʮ֡������£���ÿ֡�ƶ�1/12����λ
         * ÿ���ƶ�5����λ
        transform.position = position;
        */
        //���ı���position��ֵ��transform���position
        //Debug.Log(hor);//��ʾhor��ֵ
        //GetComponent<�����>();
        if (Mathf.Abs(HeroBody.velocity.x) < MaxSpeed)
            //δ�ﵽ����ٶȣ�ʩ��������
        {
            HeroBody.AddForce(Vector2.right * hor * MoveForce);
            //Debug.Log(hor);
        }

        if (Mathf.Abs(HeroBody.velocity.x) > 5)
            //�Ѵﵽ����ٶ�
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed,
                                            HeroBody.velocity.y);
            //����Hero�����ٶ�(x,y)
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
            //�ڵ�����
        {
            if (Input.GetButtonDown("Jump"))//��������Ծ��
            {
                bJump = true;
            }
        }
            
    }
    void flip()//ת��
    {
        Vector3 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
        bFaceRight = !bFaceRight;//ÿתһ��bFaceRight��һ��
    }
    private void FixedUpdate()
    /*�̶�����
     * ���ʺϽ�ɫ�ƶ�
     */
    {
        if (bJump)
        {
            HeroBody.AddForce(Vector2.up * JumpForce);
            bJump = false;
        }
    }
}
