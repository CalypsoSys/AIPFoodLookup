using AIPFoodLookup.ViewModel;
using Plugin.MauiMTAdmob;
using Plugin.MauiMTAdmob.Controls;
using Plugin.MauiMTAdmob.Extra;


namespace AIPFoodLookup
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            //myAds.LoadAd();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                var adView = new MTAdView
                {
                    BackgroundColor = Colors.Transparent,
                    AdSize = BannerSize.FullBanner,
                    IsVisible = true
                };
                Grid.SetRow(adView, 5);
                MainGrid.Children.Add(adView);
                adView.LoadAd();
            }
        }
    }
}
