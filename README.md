UnityTapTool
# 简介
UnityTapTool 是一个 Unity 插件，用于在 Unity 中快速接入tap各个安卓功能模块。
此模块用于游戏主分支，不涉及tap具体逻辑只是实现相关使用接口
## 前期配置
1. 在项目工程中导入该插件。
2. 在对应地点初始化TapConfig。
3. 在对应的地点通过TapConfig使用对应功能

```c# 
//初始化
TapConfig.Init();
TapConfig.InitLogin();
TapConfig.InitUserId();
TapConfig.InitGiftCode();
TapConfig.InitAd();
```

```c#
//登录
TapConfig.tapLogin.Login();
//兑换码
TapConfig.giftCode.StartRequest(giftCode,onFinish);
//广告
TapConfig.tapAd.Show(info,showCallBack);
```

## Common
实现了一个通用的奖励回调系统，用于统一视频广告和兑换码的奖励兑换逻辑
也可以不使用该系统去进行奖励兑换。
```c#
//注入奖励处理
RewardConfig.AddRewardHandle(rewardHandle);
//处理奖励
RewardConfig.HandleReward(rewardItem);
```