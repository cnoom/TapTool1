using System;
using TapTap.TapAd;

namespace com.cnoom.taptool.Runtime.Ad
{
    public interface ITapAd
    {
        /// <summary>
        /// 广告初始化
        /// </summary>
        void Init();
        
        /// <summary>
        /// 加载广告
        /// </summary>
        void Load(RewardAdInfo info);
        
        /// <summary>
        /// 广告完成后的回调
        /// </summary>
        /// <param name="showCallback"></param>
        void Show(RewardAdInfo info,Action<TapRewardVideoAd> showCallback,Action onNoAd = null);
    }
}