using com.cnoom.taptool.Runtime.Common;

namespace com.cnoom.taptool.Runtime.Ad
{
    public record RewardAdInfo(int adId,RewardItem rewardItem)
    {
        public int adId { get; } = adId;
        public RewardItem rewardItem { get; } = rewardItem;
    }
}