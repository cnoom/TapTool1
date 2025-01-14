using System;
using System.Diagnostics.CodeAnalysis;
using TapSDK.Login;

namespace com.cnoom.taptool.Runtime.Login
{
    public interface ITapLogin
    {
        /// <summary>
        /// 登录回调
        /// </summary>
        Action<TapTapAccount> onLogin { get; set; }
        
        /// <summary>
        /// 当前登录用户
        /// </summary>
        TapTapAccount account { get; }
        
        /// <summary>
        /// 登录
        /// </summary>
        void Login();
        
        /// <summary>
        /// 登出
        /// </summary>
        void Logout();
        
        /// <summary>
        /// 检查登录状态,检查完毕后执行回调
        /// </summary>
        /// <param name="onFinish"></param>
        /// <returns></returns>
        void CheckLogin([NotNull]Action<bool> onFinish);
    }
}