using System;
using System.Diagnostics.CodeAnalysis;

namespace com.cnoom.taptool.Runtime.Login
{
    public interface ITapLogin
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
        
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