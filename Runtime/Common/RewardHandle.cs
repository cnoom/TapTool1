using System;
using Action = System.Action;

namespace com.cnoom.taptool.Runtime.Common
{
    public class RewardHandle : IRewardHandle
    {
        Func<string, bool> canHandle;
        Action<RewardItem> handle;

        public bool CanHandle(string rewardName)
        {
            return canHandle(rewardName);
        }

        public void Handle(RewardItem rewardItem)
        {
            handle(rewardItem);
        }
        
        public class Builder
        {
            private RewardHandle rewardHandle = new RewardHandle();

            public Builder CanHandle(Func<string, bool> canHandle)
            {
                rewardHandle.canHandle = canHandle;
                return this;
            }

            public Builder Handle(Action<RewardItem> handle)
            {
                rewardHandle.handle = handle;
                return this;
            }

            public RewardHandle Build()
            {
                return rewardHandle;
            }
        }
    }
}