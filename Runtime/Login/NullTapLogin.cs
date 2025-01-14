using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.cnoom.taptool.Runtime.Login
{
    /// <summary>
    /// 空实现,用于编辑器下
    /// </summary>
    public class NullTapLogin : ITapLogin
    {

        public void Init()
        {
            Debug.Log("TapLogin Init");
        }
        public void Login()
        {
            Debug.Log("TapLogin Login");
        }
        
        public void Logout()
        {
            Debug.Log("TapLogin Logout");
        }
        
        public void CheckLogin(Action<bool> onFinish)
        {
            Debug.Log("TapLogin CheckLogin");
            onFinish?.Invoke(true);
        }
    }
}