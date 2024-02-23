using AIPFoodLookup.ViewModel;
using Plugin.MauiMTAdmob;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace AIPFoodLookup
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

#if DEBUG
#endif
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            myAds.LoadAd();
        }
    }
}
