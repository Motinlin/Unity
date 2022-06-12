using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playertran;
    public Vector3 offset = new Vector3(0, 1, 0);/*用public 实现在unity中可以改变offset*/
    void Start()
    {
        playertran = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playertran != null)/*防止playertran为空*/
            transform.position = playertran.position + offset;
    }
}
