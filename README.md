# Dont-Make-Me-Laugh
基于Unity实现：双人对抗横板卷轴滚动游戏，红色方玩家对麦克风输入声音进行角色的上下移动，蓝色方玩家在屏幕的右侧区域进行障碍物放置，阻挡红色方玩家的前进。
## 基础信息
+ 游戏引擎：Unity 2022.3.14f1c1
+ 渲染管线：HDRP

# 游戏机制
![image](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/dce25af4-7eee-47a1-adbe-d496c5d203c1)
## 玩家A：声音控制上下移动
玩家的音高控制在一个分贝区间时角色能够达到平稳前进，音高高于这个区间时角色上升，音高低于这个区间时角色下降
呈现：玩家输入一个音量足够大的声音，然后角色快速上升，再慢慢下落
## 玩家B：鼠标拖动障碍物，空格旋转
+ 能量值：自然增长，放置障碍物会进行消耗
+ 自然增长值：1点，间隔2秒
+ 最大值：能量值有最大值，当前能量值不能够超过最大值

# 美术
## 常规障碍物：消耗1点能量，选择后随机放下一种
障碍物1：长条
障碍物2：L型
障碍物3：T型
障碍物4：方型

![BasicBlockImage1](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/1ab20c21-1185-4512-9552-4e32aae40a2d)
![BasicBlockImage2](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/1bbc98ef-1f56-4e9a-9971-6893130bad26)

## 拓展障碍物：
+ 箭：玩家B从选择栏中选中之后能够放置在生成区内，通过旋转来选择瞄准方向，放置后能够将箭发射出去，在箭击中目标前，能够根据角色的位置进行角度修正
+ 弹力球：同样可以选择方向，放置后会向选定的方向发射出去并且能够在场景上下边界和障碍物之间进行反弹，弹力球击中玩家A的时候玩家B会获得笑脸值（待定）并且会将玩家在Y方向上击退
+ 慢速螺旋桨：十字形的长螺旋桨，很大，放置后能够缓慢转动
+ 方块心脏：会周期性变大的方块型障碍物，最小状态较小，最大状态较大，方块心脏变大的时候速度较慢，变小速度很快

![ArrowImage](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/3bb5e783-c3a4-4af2-b6c5-21db72932274)
![PowerballImage](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/bbd31924-8112-4a37-bcec-d45dbfc4f5cc)
![PropellerImage](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/c96fb6a5-31b4-49c8-98d5-83805c92e41e)
![HeartImageObject](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/f7a54892-a9f3-46a7-9c9e-2245976977ff)


# 玩家B的得分机制
## 破坏：有些障碍物在玩家A控制的角色碰撞上了之后就会摧毁，此时玩家B得分
## 阻挡：有些障碍物会持续对角色进行阻挡，具体呈现为角色在障碍物内速度减缓，并且需要隔一段时间才能够为玩家B提供分数

# 游戏截图
![封面图](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/1fea8e11-283d-47e6-8056-cf1746fac5bb)
![4](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/5699be9f-79ea-4306-a2ab-f974b1b53a21)
![3](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/0acd1519-5edc-4505-ba6f-7c671ff3efbe)
![2](https://github.com/satsuki-64/Dont-Make-Me-Laugh/assets/49782051/24cd5159-4a97-4943-9c0e-b69f541a36f4)
