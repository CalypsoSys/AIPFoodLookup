using AIPFoodLookup.ViewModel;
using Microsoft.Extensions.Logging;
using Plugin.MauiMTAdmob;

namespace AIPFoodLookup
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMTAdmob()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<CatagoriesPage>();
            builder.Services.AddSingleton<CategoriesViewModel>();

            builder.Services.AddTransient<CategoryDetailsPage>();
            builder.Services.AddTransient<CategoryDetailsModel>();

            builder.Services.AddTransient<CategoriesListPage>();
            builder.Services.AddTransient<CategoriesListModel>();

            return builder.Build();
        }
    }
}
