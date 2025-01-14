using System;
using System.Collections.Generic;
using TapTap.TapAd;
using UnityEngine;

namespace com.cnoom.taptool.Runtime.Ad
{
    public class CnoomTapAd : ITapAd
    {

        private TapAdConfig adConfig;
        private Dictionary<RewardAdInfo, TapRewardVideoAd> adDic = new Dictionary<RewardAdInfo, TapRewardVideoAd>();
        private List<RewardAdInfo> rewardAdInfoList = new List<RewardAdInfo>();
        public CnoomTapAd(TapAdConfig config, List<RewardAdInfo> list)
        {
            adConfig = config;
            rewardAdInfoList = list;
        }

        public void Init()
        {
            if(PlayerPrefs.GetInt("TapManager_Ad", 0) == 0)
            {
                TapAdSdk.RequestPermissionIfNecessary();
                PlayerPrefs.SetInt("TapManager_Ad", 1);
                PlayerPrefs.Save();
            }
            TapAdSdk.Init(adConfig, new CnoomCustomController(), LoadAll);
        }

        public void Load(RewardAdInfo info)
        {
            adDic.TryAdd(info, null);

            var request = new TapAdRequest.Builder()
                .SpaceId(info.adId)
                .RewardName(info.rewardItem.name)
                .RewardCount(info.rewardItem.number)
                .Build();

            if(Application.isEditor)
            {
                adDic[info] = new TapRewardVideoAd(request);
                return;
            }

            var ad = adDic[info];
            if(ad != null)
            {
                ad.Dispose();
                adDic[info] = null;
            }

            var videoAd = new TapRewardVideoAd(request);
            videoAd.SetLoadListener(new RewardVideoAdLoadListener(info, adDic));
            adDic[info] = videoAd;
            adDic[info].Load();
        }

        private void LoadAll()
        {
            foreach (RewardAdInfo info in rewardAdInfoList)
            {
                Load(info);
            }
        }

        public void Show(RewardAdInfo info, Action<TapRewardVideoAd> showCallback, Action onNoAd)
        {
            if(Application.isEditor)
            {
                showCallback?.Invoke(adDic[info]);
                return;
            }
            var ad = adDic[info];
            if(ad == null)
            {
                Load(info);
                onNoAd?.Invoke();
                return;
            }
            ad.SetInteractionListener(new RewardVideoInteractionListener(showCallback));
            ad.Show();
        }

        private class RewardVideoInteractionListener : IRewardVideoInteractionListener
        {
            private readonly Action<TapRewardVideoAd> showCallback;

            public RewardVideoInteractionListener(Action<TapRewardVideoAd> showCallback)
            {
                this.showCallback = showCallback;
            }


            public void OnAdShow(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
            public void OnAdClose(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
            public void OnVideoComplete(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
            public void OnVideoError(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
            public void OnRewardVerify(TapRewardVideoAd ad, bool rewardVerify, int rewardAmount, string rewardName, int code, string msg)
            {
                if(rewardVerify) showCallback?.Invoke(ad);
            }
            public void OnSkippedVideo(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
            public void OnAdClick(TapRewardVideoAd ad)
            {
                throw new NotImplementedException();
            }
        }

        private class RewardVideoAdLoadListener : IRewardVideoAdLoadListener
        {
            private readonly RewardAdInfo info;
            private readonly Dictionary<RewardAdInfo, TapRewardVideoAd> adDic;
            public RewardVideoAdLoadListener(RewardAdInfo info, Dictionary<RewardAdInfo, TapRewardVideoAd> dic)
            {
                this.info = info;
                adDic = dic;
            }

            public void OnError(int code, string message)
            {
                Debug.LogError($"RewardVideoAdLoadListener OnError code:{code} message:{message}");
            }
            public void OnRewardVideoAdCached(TapRewardVideoAd ad)
            {
                Debug.Log($"RewardVideoAdLoadListener OnRewardVideoAdCached ad:{ad}");
            }
            public void OnRewardVideoAdLoad(TapRewardVideoAd ad)
            {
                Debug.Log($"RewardVideoAdLoadListener OnRewardVideoAdLoad ad:{ad}");
                adDic[info] = ad;
            }
        }
    }
}