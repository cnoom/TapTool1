using System;
using System.Collections.Generic;
using TapTap.TapAd;

namespace com.cnoom.taptool.Runtime.Ad
{
    public class NullTapAd : ITapAd
    {
        private Dictionary<RewardAdInfo, TapRewardVideoAd> adDic = new Dictionary<RewardAdInfo, TapRewardVideoAd>();

        public void Init()
        {

        }
        public void Load(RewardAdInfo info)
        {
            if(adDic.ContainsKey(info))
            {
                return;
            }
            var requeset = new TapAdRequest.Builder()
                .SpaceId(info.adId)
                .RewardName(info.rewardItem.name)
                .RewardCount(info.rewardItem.number)
                .Build();
            adDic.Add(info, new TapRewardVideoAd(requeset));
        }

        public void Show(RewardAdInfo info, Action<TapRewardVideoAd> showCallback, Action onNoAd = null)
        {
            if(adDic.TryGetValue(info, out var ad))
            {
                showCallback?.Invoke(ad);
                return;
            }
            onNoAd?.Invoke();
        }
    }
}