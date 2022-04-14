using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    // Start 函数只在游戏开始时执行一次
    void Start()
    {
        //transform.position.x = 10;
        /*
         尝试在游戏开始时修改x的位置
        transform.position.x = 10;
        但会报错，似乎说position不能直接改
        */
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;//60fps

    }

    // Update is called once per frame
    // Update函数会在每帧执行
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        /*
            声明ver来存垂直值
            声明hor来存水平值
            都是按下值为1
            未按下值为-1
         */
        Vector2 position = transform.position;
        /*
         vector2是一种存两个数据的变量,(x,y)
        */
        position.x += 5f * hor * Time.deltaTime;
        position.y += 5f * ver * Time.deltaTime;
        /* deltaTime代表渲染一帧所需要的时间
         * 在固定了运行帧数之后，才能保证在所有机器上移动的速度一样
         * 在六十帧的情况下，即每帧移动1/12个单位
         * 每秒移动5个单位
         */
        /*
         * 修改position的值
         * f代表浮点数，在Unity中使用的都是浮点数，所以要加f表示小数
         */
        transform.position = position;
        //将改变后的position赋值给transform里的position
        //Debug.Log(hor);//显示hor的值
    }
}
