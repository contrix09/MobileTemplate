using CommonServiceLocator;
using MobileTemplate.Core;
using MobileTemplate.Services;
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

            navigation.SetRootPage("MainView", "Welcome to Xamarin.Forms!");
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
