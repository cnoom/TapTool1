using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;

namespace com.cnoom.taptool.Runtime.GiftCode
{
    /// <summary>
    /// 无服务器兑换
    /// </summary>
    public class CnoomTapGiftCode : IGiftCode
    {
        private const string AllCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string APIUrl = "https://poster-api.xd.cn/api/v1.0/cdk/game/submit-simple";
        private const string ContentType = "application/json";
        private readonly string characterId;
        public CnoomTapGiftCode()
        {
            characterId = TapConfig.userId;
        }
        
        public IEnumerator StartRequest(string giftCode, Action<GiftJsonData> onFinish)
        {
            // 获取当前时间戳（秒）
            int timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            // 生成随机字符串
            string nonceStr = RandomStr();
            // 拼接并加密 sign 参数
            string sign = GetSign(timestamp, nonceStr);

            // 构建请求参数
            string requestBody = "{\"client_id\":\"" + TapConfig.clientId + "\",\"gift_code\":\"" + giftCode + "\",\"character_id\":\"" + characterId + "\",\"nonce_str\":\"" + nonceStr + "\",\"timestamp\":" + timestamp + ",\"sign\":\"" + sign + "\"}";

            // 创建 UnityWebRequest 对象
            UnityWebRequest request = new UnityWebRequest(APIUrl, "POST");

            // 设置请求头
            request.SetRequestHeader("Content-Type", ContentType);

            // 设置请求体
            byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // 发送请求
            yield return request.SendWebRequest();

            // 处理响应
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API request succeeded");
                Debug.Log(request.downloadHandler.text);
                GiftJsonData jsonData = JsonUtility.FromJson<GiftJsonData>(request.downloadHandler.text);
                onFinish(jsonData);
            }
            else
            {
                Debug.Log("API request failed: " + request.error);
                Debug.Log(request.downloadHandler.text);
                onFinish(null);
            }
        }
        
        private string RandomStr()
        {
            Random random = new Random();
            string randomString = "";
            for (int i = 0; i < 5; i++)
            {
                int randomIndex = random.Next(AllCharacters.Length);
                randomString += AllCharacters[randomIndex];
            }
            return randomString;
        }
        
        private string GetSign(int timestamp, string nonceStr)
        {
            // 拼接参数并进行 SHA1 加密
            string signString = timestamp + nonceStr + characterId;
            byte[] signBytes = Encoding.UTF8.GetBytes(signString);
            byte[] signHash = new SHA1CryptoServiceProvider().ComputeHash(signBytes);
            string sign = BitConverter.ToString(signHash).Replace("-", "").ToLowerInvariant();

            return sign;
        }
    }
}