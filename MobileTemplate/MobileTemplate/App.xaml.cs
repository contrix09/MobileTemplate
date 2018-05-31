using CommonServiceLocator;
using MobileTemplate.Common;
using MobileTemplate.Core;
using MobileTemplate.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileTemplate
{
    public partial class App : Application
	{
		public App (AppSetup appSetup)
		{
			InitializeComponent();

            AppContainer.Container = appSetup.CreateContainer();
            AppContainer.Container.BeginLifetimeScope();
		}

		protected override void OnStart ()
		{
            var navigation = ServiceLocator.Current.GetInstance<INavigationService>();

            navigation.SetRootPage(ViewNames.MAIN_VIEW, "Welcome to Xamarin.Forms!");
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
