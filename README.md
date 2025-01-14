UnityTapTool
# 简介
UnityTapTool 是一个 Unity 插件，用于在 Unity 中快速接入tap各个安卓功能模块。
## 前期配置
1. 下载相关 TapSDK 并导入 Unity 工程。
2. 在 Unity 中安装 TapSDK 插件。
3. 在UnityTapTool中配置TapSDK的相关配置。
4. 在游戏启动时初始化TapConfig。

```c#
TapConfig.Init();
TapConfig.InitLogin();
TapConfig.InitUserId();
TapConfig.InitGiftCode();
TapConfig.InitAd();
```