using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public float ParallaxFactor = 0.1f;
    public float FramesParllaxFactor = 0.3f;
    public float SmoothX = 4;
    public Transform[] BackGrounds;
    private Transform cam;
    private Vector3 camPrePos;
    void Start()
    {
        camPrePos = cam.position;//初始化
    }    
    private void Awake()//比Start先执行
    {
        cam = Camera.main.transform;
        
    }
    void bkParallax()
    {
        float fparallax = (camPrePos.x - cam.position.x) * ParallaxFactor;
        for( int i = 0; i<BackGrounds.Length; i++)
        {
            float bkNewX = BackGrounds[i].position.x + fparallax * (1 + i * FramesParllaxFactor);
            Vector3 bkNewPos = new Vector3(bkNewX, BackGrounds[i].position.y, BackGrounds[i].position.z);
            BackGrounds[i].position = Vector3.Lerp(BackGrounds[i].position, bkNewPos, Time.deltaTime * SmoothX);
        }
        camPrePos = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
