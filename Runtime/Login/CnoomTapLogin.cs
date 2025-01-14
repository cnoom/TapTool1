using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapSDK.Login;
using UnityEngine;

namespace com.cnoom.taptool.Runtime.Login
{
    public class CnoomTapLogin : ITapLogin
    {

        public Action<TapTapAccount> onLogin { get; set; }
        public TapTapAccount account => tapAccount;

        private TapTapAccount tapAccount;
        
        public void Login()
        {
            TaskLogin();
        }
        
        public void Logout()
        {
            TapTapLogin.Instance.Logout();
        }
        
        public async void CheckLogin(Action<bool> onFinish)
        {
            try {
                TapTapAccount account = await TapTapLogin.Instance.GetCurrentTapAccount();
                bool isLogin = account != null;
                if (isLogin) {
                    tapAccount = account;
                    onLogin?.Invoke(tapAccount);
                }
                onFinish.Invoke(isLogin);
            } catch (Exception e) {
                Debug.Log($"获取用户信息失败 {e.Message}");
            }
        }

        private async void TaskLogin()
        {
            try
            {
                // 定义授权范围
                List<string> scopes = new List<string>
                {
                    TapTapLogin.TAP_LOGIN_SCOPE_PUBLIC_PROFILE
                };
                // 发起 Tap 登录
                tapAccount = await TapTapLogin.Instance.LoginWithScopes(scopes.ToArray());
                onLogin?.Invoke(tapAccount);
                Debug.Log($"登录成功，当前用户 ID：{tapAccount.unionId}");
            }
            catch (TaskCanceledException)
            {
                Debug.Log("用户取消登录");
            }
            catch (Exception exception)
            {
                Debug.Log($"登录失败，出现异常：{exception}");
            }
        }
    }
}