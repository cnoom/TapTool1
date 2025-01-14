using System;
using com.cnoom.taptool.Runtime.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.cnoom.taptool.Runtime.Ad
{
    public class NullTapAd : ITapAd
    {

        public void Init()
        {

        }
        public void Load(RewardAdInfo info)
        {
            Debug.Log("TapAd Load");
        }

        public void Show(RewardAdInfo info, Action<RewardItem> showCallback, Action onNoAd = null)
        {
            if(Random.Range(0, 10) > 5)
            {
                Debug.Log("TapAd Show");
                showCallback(new RewardItem("TestItem",1));
                return;
            }
            Debug.Log("TapAd No Ad");
            onNoAd?.Invoke();
        }
    }
}