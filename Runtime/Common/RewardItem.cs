using System;

namespace com.cnoom.taptool.Runtime.Common
{
    [Serializable]
    public record RewardItem(string name,int number)
    {
        public string name { get; } = name;
        public int number { get; } = number;
    }
}