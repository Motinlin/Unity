using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    // Start ����ֻ����Ϸ��ʼʱִ��һ��
    void Start()
    {
        //transform.position.x = 10;
        /*
         ��������Ϸ��ʼʱ�޸�x��λ��
        transform.position.x = 10;
        ���ᱨ���ƺ�˵position����ֱ�Ӹ�
        */
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;//60fps

    }

    // Update is called once per frame
    // Update��������ÿִ֡��
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        /*
            ����ver���洹ֱֵ
            ����hor����ˮƽֵ
            ���ǰ���ֵΪ1
            δ����ֵΪ-1
         */
        Vector2 position = transform.position;
        /*
         vector2��һ�ִ��������ݵı���,(x,y)
        */
        position.x += 5f * hor * Time.deltaTime;
        position.y += 5f * ver * Time.deltaTime;
        /* deltaTime������Ⱦһ֡����Ҫ��ʱ��
         * �ڹ̶�������֡��֮�󣬲��ܱ�֤�����л������ƶ����ٶ�һ��
         * ����ʮ֡������£���ÿ֡�ƶ�1/12����λ
         * ÿ���ƶ�5����λ
         */
        /*
         * �޸�position��ֵ
         * f������������Unity��ʹ�õĶ��Ǹ�����������Ҫ��f��ʾС��
         */
        transform.position = position;
        //���ı���position��ֵ��transform���position
        //Debug.Log(hor);//��ʾhor��ֵ
    }
}
