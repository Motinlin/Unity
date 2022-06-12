using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float XSmooth = 8;
    public float YSmooth = 8;/*每秒移动距离，public类型方便调整*/
    public float XDistance = 2;
    public float YDistance = 2;/*范围，超过这个范围摄像机开始移动*/
    public Vector2 MaxXandY;
    public Vector2 MinXandY;/*最大最小值*/
    public Transform Hero;
    void Start()
    {
       
    }
    bool MoveX()/*x方向的力*/
    {
        if (Mathf.Abs(Hero.position.x - transform.position.x) > XDistance)/*Mathf.Abs 取绝对值*/
            return true;
        else
            return false;
    }
    bool MoveY()
    {
        if (Mathf.Abs(Hero.position.y - transform.position.y) > YDistance)
            return true;
        else
            return false;
    }
    void FollowHero()/*移动跟随*/
    {
        float newX = transform.position.x;
        float newY = transform.position.y;/*当前位置赋值给摄像机*/
        if (MoveX())
            newX = Mathf.Lerp(transform.position.x, Hero.position.x, XSmooth * Time.deltaTime);
        newX = Mathf.Clamp(newX, MinXandY.x, MaxXandY.x);
        if (MoveY())
            newY = Mathf.Lerp(transform.position.y, Hero.position.y, YSmooth * Time.deltaTime);
        newY = Mathf.Clamp(newY, MinXandY.y, MaxXandY.y);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        FollowHero();
    }
}
