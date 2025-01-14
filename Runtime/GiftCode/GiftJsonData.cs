using System;
using System.Collections.Generic;
using com.cnoom.taptool.Runtime.Common;

namespace com.cnoom.taptool.Runtime.GiftCode
{
    [Serializable]
    public class GiftJsonData
    {
        public string activity_id;
        public string c_sign;
        public string content;
        public List<RewardItem> content_obj;
        public Dictionary<string, object> custom;
        public int error;
        public string nonce_str;
        public string sign;
        public bool success;
        public long timestamp;
    }
}