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
            //如果碰到的是人物，则将其显示出来，并重新开始游戏。
        {
            //在掉落位置实例化一个水花
            Instantiate(splash, col.transform.position, transform.rotation);
            //相机不再跟随
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
            hero.death();//使角色掉落死亡并重开游戏
            

        }
        
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(splash, col.transform.position, transform.rotation);
        }
    }


}
