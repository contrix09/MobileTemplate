
using Foundation;
using MobileTemplate.iOS.Core;
using UIKit;

namespace MobileTemplate.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private App app;

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSAppSetup()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void WillTerminate(UIApplication uiApplication)
        {
            this.app.OnStop();
            base.WillTerminate(uiApplication);
        }
    }
}
