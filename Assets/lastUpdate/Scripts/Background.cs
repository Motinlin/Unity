using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float parallaxFactor = 0.1f;//整体
    public float frameParallaxFactor = 0.3f;
    public float smoothX = 4;
    public Transform[] backgrounds;

    private Transform cam;
    private Vector3 camPrePos;

    private void Awake()
    {
        cam = Camera.main.transform;
        camPrePos = cam.position;//可以写在start里面
        /*两条语句顺序更改会报错*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void bkParallax()//背景移动
    {
        float fparallax = (camPrePos.x - cam.position.x) * parallaxFactor;
        for(int i = 0; i < backgrounds.Length; i++)
        {
            //每一层运动量
            float bkNewX = backgrounds[i].position.x + fparallax * (1 + i * frameParallaxFactor);
            Vector3 bkNewPos = new Vector3(bkNewX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bkNewPos, Time.deltaTime * smoothX);
        }
        camPrePos = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
