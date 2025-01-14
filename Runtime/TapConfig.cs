using System;
using System.Diagnostics.CodeAnalysis;
using com.cnoom.taptool.Runtime.Ad;
using com.cnoom.taptool.Runtime.GiftCode;
using com.cnoom.taptool.Runtime.Login;


namespace com.cnoom.taptool.Runtime
{
    public static class TapConfig
    {
        public static string clientId { get; private set; }
        public static string clientToken { get; private set; }
        public static string userId { get; private set; }

        public static ITapLogin tapLogin { get; private set; } = new NullTapLogin();
        public static IGiftCode giftCode { get; private set; } = new NullGiftCode();
        public static ITapAd tapAd { get; private set; } = new NullTapAd();

        public static void TapCoreInit([NotNull]Action initAction)
        {
            initAction.Invoke();
        }

        public static void InitUserId([NotNull]string id)
        {
            userId = id;
        }

        public static void InitLogin([NotNull]ITapLogin login)
        {
            tapLogin = login;
        }

        public static void InitGiftCode([NotNull]IGiftCode gc)
        {
            giftCode = gc;
        }

        public static void InitAd([NotNull]ITapAd ad)
        {
            tapAd = ad;
        }
    }
}