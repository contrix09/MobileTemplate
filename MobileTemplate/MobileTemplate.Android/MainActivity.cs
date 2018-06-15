using Android.App;
using Android.Content.PM;
using Android.OS;
using MobileTemplate.Droid.Core;

namespace MobileTemplate.Droid
{
    [Activity(Label = "MobileTemplate", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private App _app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            var appSetup = new AndroidAppSetup();
            this._app = new App();
            LoadApplication(this._app);
        }

        protected override void OnStop()
        {
            this._app.OnStop();
            base.OnStop();
        }
    }
}

