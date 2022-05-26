using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rocket;
    HeroController playerCtrl;
    public float Speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<HeroController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
            if (playerCtrl.bFaceRight)//朝向为右,不用旋转
            {
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0,0,0));
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(Speed, 0);
            }
            else
            {
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 180));
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-Speed, 0);
            }
        }
    }
}
