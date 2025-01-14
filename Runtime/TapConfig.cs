using com.cnoom.taptool.Runtime.Ad;
using com.cnoom.taptool.Runtime.GiftCode;
using com.cnoom.taptool.Runtime.Login;
using TapSDK.Core;
using TapTap.TapAd;

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

        public static void Init(TapTapSdkOptions coreOptions, TapTapSdkBaseOptions[] otherOptions = null)
        {
            clientId = coreOptions.clientId;
            clientToken = coreOptions.clientToken;
            if(otherOptions == null)
            {
                TapTapSDK.Init(coreOptions);
                return;
            }
            TapTapSDK.Init(coreOptions, otherOptions);
        }

        public static void InitUserId(string id)
        {
            userId = id;
        }

        public static void InitLogin(ITapLogin login)
        {
            tapLogin = login;
        }

        public static void InitGiftCode(IGiftCode gc)
        {
            giftCode = gc;
        }

        public static void InitAd(TapAdConfig config, ITapAd ad)
        {
            tapAd = ad;
        }
    }
}