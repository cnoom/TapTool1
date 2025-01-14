using TapTap.TapAd;

namespace com.cnoom.taptool.Runtime.Ad
{
    public class CnoomCustomController : ICustomController
    {
        public bool CanUseLocation { get; } = true;
        public TapAdLocation GetTapAdLocation { get; }
        public bool CanUsePhoneState { get; } = true;
        public string GetDevImei { get; }
        public bool CanUseWifiState { get; } = true;
        public bool CanUseWriteExternal { get; } = true;
        public string GetDevOaid { get; }
        public bool Alist { get; } = true;
        public bool CanUseAndroidId { get; } = true;
        public CustomUser ProvideCustomer()
        {
            return new CustomUser();
        }
    }
}