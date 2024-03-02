using Plugin.MauiMTAdmob;

namespace AIPFoodLookup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            if (DeviceInfo.Platform == DevicePlatform.Android) 
            {
                CrossMauiMTAdmob.Current.UserPersonalizedAds = true;
                CrossMauiMTAdmob.Current.ComplyWithFamilyPolicies = true;
                CrossMauiMTAdmob.Current.UseRestrictedDataProcessing = true;
#if DEBUG
                CrossMauiMTAdmob.Current.AdsId = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3940256099942544/2934735716";
                CrossMauiMTAdmob.Current.TestDevices = new List<string>() { };
#else
                CrossMauiMTAdmob.Current.AdsId = DeviceInfo.Platform == DevicePlatform.Android ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3940256099942544/2934735716";
#endif
            }
        }
    }
}
