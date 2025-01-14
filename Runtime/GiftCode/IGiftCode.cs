using System;
using System.Collections;

namespace com.cnoom.taptool.Runtime.GiftCode
{
    public interface IGiftCode
    {
        /// <summary>
        /// 兑换码
        /// </summary>
        /// <param name="giftCode"></param>
        /// <param name="onFinish"></param>
        /// <returns></returns>
        IEnumerator StartRequest(string giftCode, Action<GiftJsonData> onFinish);
    }
}