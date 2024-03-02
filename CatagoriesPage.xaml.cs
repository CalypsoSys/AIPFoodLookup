using AIPFoodLookup.ViewModel;
using Plugin.MauiMTAdmob.Controls;
using Plugin.MauiMTAdmob.Extra;

namespace AIPFoodLookup;

public partial class CatagoriesPage : ContentPage
{
	public CatagoriesPage(CategoriesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
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
            Grid.SetRow(adView, 2);
            MainGrid.Children.Add(adView);
            adView.LoadAd();
        }
    }
}