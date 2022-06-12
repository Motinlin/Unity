using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteSortingLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth hero;
    public GameObject splash;
    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            //��������������������ʾ�����������¿�ʼ��Ϸ��
        {
            //�ڵ���λ��ʵ����һ��ˮ��
            Instantiate(splash, col.transform.position, transform.rotation);
            //������ٸ���
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
            hero.death();//ʹ��ɫ�����������ؿ���Ϸ
            

        }
        
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(splash, col.transform.position, transform.rotation);
        }
    }


}
