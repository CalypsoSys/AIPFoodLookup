using Foundation;
using Google.MobileAds;
using Plugin.MauiMTAdmob;
using UIKit;

namespace AIPFoodLookup
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
#if IOS_ADMOB
            MobileAds.SharedInstance.Start(CompletionHandler);
#endif
            return base.FinishedLaunching(application, launchOptions);
        }

        private void CompletionHandler(InitializationStatus status) { }

        public AppDelegate()
        {
#if IOS_ADMOB
            //If you don't have a license code, you can use the following line instead:
            CrossMauiMTAdmob.Current.Init();
#endif
        }

        public override void OnActivated(UIApplication application)
        {
            base.OnActivated(application);
#if IOS_ADMOB
            CrossMauiMTAdmob.Current.OnResume();
#endif
        }

        public override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            // Fetch data here and call the completion handler
            completionHandler(UIBackgroundFetchResult.NewData);
        }
    }
}
