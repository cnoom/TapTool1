using System.Collections.Generic;
using UnityEngine;

namespace com.cnoom.taptool.Runtime.Common
{
    public static class RewardConfig
    {
        private static readonly List<IRewardHandle> RewardHandles = new List<IRewardHandle>();

        
        public static void AddRewardHandle(IRewardHandle rewardHandle)
        {
            if(RewardHandles.Contains(rewardHandle))
            {
                Debug.LogError("RewardHandle already exists");
                return;
            }
            RewardHandles.Add(rewardHandle);
        }

        public static void RemoveRewardHandle(IRewardHandle rewardHandle)
        {
            RewardHandles.Remove(rewardHandle);
        }

        public static void HandleReward(RewardItem rewardItem)
        {
            foreach (IRewardHandle rewardHandle in RewardHandles)
            {
                if(!rewardHandle.CanHandle(rewardItem.name)) continue;
                rewardHandle.Handle(rewardItem);
                return;
            }
            Debug.LogError("RewardHandle not found, rewardName: " + rewardItem.name);
        }
    }
}