using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    void Start()
    {
        //Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            float rotation = Random.Range(0, 360);
            Instantiate(explosion, transform.position,
                        Quaternion.Euler(0, 0, rotation));//旋转的是爆炸动画，不是火箭
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hurt();
            //当碰到的是敌人，则调用Enemy的Hurt使得敌人HP--；
        }
    }
}
