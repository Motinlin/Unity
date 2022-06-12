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
    private Transform mGroundCheck;//������
    public float JumpForce = 100;//������
    public AudioClip[] JumpClips;
    public AudioSource audioSource;
    Animator anim;//����������
    Collider2D HeroCollider;
    private GameObject bomb;

    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;//60fps
        HeroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        GameObject.Find("Hero").GetComponent<LayBombs>().enabled = true;
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
            //HeroBody.AddForce(Vector2.right * hor * MoveForce);
            //Debug.Log(hor);
        }

        if (Mathf.Abs(HeroBody.velocity.x) > MaxSpeed)
            //�Ѵﵽ����ٶ�
        {
            //�ֶ����ٵ�����ٶ����£��Ӷ�ʹ��һ֡��ü��ٻ���
            HeroBody.velocity = new Vector2((MaxSpeed - 0.01f) * Mathf.Sign(HeroBody.velocity.x),
                    HeroBody.velocity.y);

            /*if (!Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << 
                LayerMask.NameToLayer("Ground")))
                //���ڵ��棬�ڿ���
            {
                //�ֶ����ٵ�����ٶ����£��Ӷ�ʹ��һ֡��ü��ٻ���
                HeroBody.velocity = new Vector2((MaxSpeed - 0.1f) * Mathf.Sign(HeroBody.velocity.x),
                    HeroBody.velocity.y);
            }*/
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
        anim.SetFloat("Speed", Mathf.Abs(hor)); //ΪSpeed��hor��ֵ
        
        //Debug.Log(hor);
    }
    void flip()//ת��
    {
        Vector3 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
        bFaceRight = !bFaceRight;//ÿתһ��bFaceRight��һ��
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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
            anim.SetTrigger("Jump");
            int i = Random.Range(0, JumpClips.Length);
            audioSource.PlayOneShot(JumpClips[i]);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shoot");
        }
    }
}
