# 学习Unity中遇到的问题
## 1.关于Sprite
### 1.1 利用Sprite Editor将一个Sprite切割分成多个
注意将其设置为Mutiple类型
### 1.2 多个Sprite组成一个父物体时
其坐标显示为对于父物体(空物体)的局部坐标(相对坐标)，应该将主要部件的坐标设为(0,0,0),以便为组合物体(父物体)创建RigidBody
## 2.关于摄像机
### 2.1 有时候Game里面没有出现搭建好的场景
检查摄像机Z轴坐标是否小于场景中Sprite的Z轴坐标
## 3.关于人物移动
### 3.1 移动人物时若不想要人物旋转(2D)
将刚体组件中的z轴锁住。
### 3.2关于实现跳跃
首先应明确什么情况下能跳跃，设置变量布尔类型变量
```c#
public bool bJump = false //因为人物一开始从空中落下
```
一般情况下，需**同时具备两个条件才能跳跃**

1.人物在地上
可通过Physicals2D射线检测
```c#
if (Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
//Ground为地面层
```
2.玩家按下了Jump
可通过Input检测是否按下了Jump
```c#
if (Input.GetButtonDown("Jump"))//按下了跳跃键
```
综上所述具体代码有两段

1.
```c#
if (Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            //在地面上
        {
            if (Input.GetButtonDown("Jump"))//按下了跳跃键
            {
                bJump = true;
            }
        }
 ```   
 2.
 ```c#
        private void FixedUpdate()
    {
        if (bJump)
        {
            HeroBody.AddForce(Vector2.up * JumpForce);
            bJump = false;
        }
    }
}
```
