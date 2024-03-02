using AIPFoodLookup.ViewModel;
using Plugin.MauiMTAdmob.Controls;
using Plugin.MauiMTAdmob.Extra;

namespace AIPFoodLookup;

public partial class CategoryDetailsPage : ContentPage
{
    public CategoryDetailsPage(CategoryDetailsModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoryDetailsModel viewModel)
        {
            viewModel.LoadDataCommand.Execute(null);
        }

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
