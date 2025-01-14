namespace com.cnoom.taptool.Runtime.Common
{
    public interface IRewardHandle
    {
        bool CanHandle(string rewardName);
        void Handle(RewardItem rewardItem);
        
        
    }
}