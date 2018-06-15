﻿
using Foundation;
using MobileTemplate.iOS.Core;
using UIKit;

namespace MobileTemplate.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private App _app;

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            var appSetup = new iOSAppSetup();
            this._app = new App();
            LoadApplication(this._app);

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void WillTerminate(UIApplication uiApplication)
        {
            this._app.OnStop();
            base.WillTerminate(uiApplication);
        }
    }
}
