using Microsoft.UI.Xaml.Controls;
using Plugin.MauiMTAdmob;

namespace AIPFoodLookup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            CrossMauiMTAdmob.Current.UserPersonalizedAds = true;
            CrossMauiMTAdmob.Current.ComplyWithFamilyPolicies = true; 
            CrossMauiMTAdmob.Current.UseRestrictedDataProcessing = true;
#if DEBUG
            CrossMauiMTAdmob.Current.AdsId = "ca-app-pub-3940256099942544/6300978111";
#else
            CrossMauiMTAdmob.Current.AdsId = "ca-app-pub-3940256099942544/6300978111";
#endif
        }
    }
}
