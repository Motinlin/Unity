# 学习Unity中遇到的问题
## 1.Sprite
### 1.1 多个Sprite组成一个父物体时
其坐标显示为对于父物体(空物体)的局部坐标(相对坐标)，应该将主要部件的坐标设为(0,0,0),以便为组合物体(父物体)创建RigidBody
### 1.2 Sprite Editor
#### 1.2.1 Slice
可以将一张Sprite分割成多个部分，注意分割前将Sprite设置为Mutiple类型
#### 1.2.2 Pivot
可以更改Sprite的支点位置，可以运用与转身与制造动画中
## 2. Camera
### 2.1 Game里面没有出现搭建好的场景
检查摄像机Z轴坐标是否小于场景中Sprite的Z轴坐标
### 2.2 实现相机跟随人物移动
利用Cinemachine,创建名为CameraConfiner的空物体为其设置碰撞体从而限定跟随范围\
**注意要为其单独设一个Layer,并取消该层与其他层的碰撞**
### 2.3 实现背景补偿
https://github.com/Motinlin/Unity/blob/main/Assets/Assets_1/Scripts/BackGround.cs
## 3.Charactor
### 3.1 移动人物时若不想要人物旋转(2D)
将刚体组件中的z轴锁住。
### 3.2 关于实现跳跃
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
### 3.3 Flip--转身
### 3.4 人物发射炮弹
### 3.5 人物血条

## 4.Animator and Animation
Animator是用来控制Animation的组件，Animator中可以有不同的Layer，每一个Layer可以有多个Animation Clip
### 4.1 Create Clips
通过点击Window-Animation添加Animation窗口后，可以在层级栏选中想要创建动画的物体，在Animation窗口中创建Animation Clips或Animator
![image](https://user-images.githubusercontent.com/96507966/170480999-d41cf2dd-3c44-47a9-a009-128876fa0640.png)

### 4.2 Layer and Parameters
Animator可以有多个Layer,Layer可以有多个Clip,通过设置动画层的权重Weight来控制不同动画层的播放
![image](https://user-images.githubusercontent.com/96507966/170481417-3646f6f2-041f-4d39-8534-9f207ce54bd3.png)

Animator中的变量总共有四种，如下\
![image](https://user-images.githubusercontent.com/96507966/170482987-e2d8db82-6f04-493b-8cdc-ade20bd9508b.png)



