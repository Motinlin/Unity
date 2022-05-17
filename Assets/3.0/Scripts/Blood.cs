using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called before the first frame update
    Transform HeroTran;
    public Vector3 offset = new Vector3(0, 1, 0);
    void Start()
    {
        HeroTran = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HeroTran.position + offset;
    }
}
