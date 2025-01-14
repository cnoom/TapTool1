using System;
using System.Collections;
using System.Collections.Generic;
using com.cnoom.taptool.Runtime.Common;

namespace com.cnoom.taptool.Runtime.GiftCode
{
    public class NullGiftCode : IGiftCode
    {

        public IEnumerator StartRequest(string giftCode, Action<GiftJsonData> onFinish)
        {
            yield return null;
            onFinish?.Invoke(new GiftJsonData
            {
                content_obj = new List<RewardItem>
                {
                    new RewardItem("NullGiftCode",1)
                }
            });
        }
    }
}