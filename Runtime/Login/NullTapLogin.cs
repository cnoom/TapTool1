using System;
using System.Collections.Generic;
using TapSDK.Login;
using UnityEngine;

namespace com.cnoom.taptool.Runtime.Login
{
    /// <summary>
    /// 空实现,用于编辑器下
    /// </summary>
    public class NullTapLogin : ITapLogin
    {

        public Action<TapTapAccount> onLogin { get; set; }

        public TapTapAccount account { get; } = new TapTapAccount
        {
            accessToken =
            {
                kid = "kid",
                macAlgorithm = "macAlgorithm",
                macKey = "macKey",
                scopeSet = new HashSet<string>(),
                tokenType = "tokenType",
            }
        };
        
        public void Login()
        {
            Debug.Log("TapLogin Login");
            onLogin?.Invoke(account);
        }
        
        public void Logout()
        {
            Debug.Log("TapLogin Logout");
        }
        
        public void CheckLogin(Action<bool> onFinish)
        {
            Debug.Log("TapLogin CheckLogin");
            onLogin?.Invoke(account);
            onFinish?.Invoke(true);
        }
    }
}