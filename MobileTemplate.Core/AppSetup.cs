using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileTemplate.Common;
using MobileTemplate.Managers.User;
using MobileTemplate.Repositories.Database;
using MobileTemplate.Repositories.User;
using MobileTemplate.Utilities.Navigation;
using MobileTemplate.ViewModels;
using MobileTemplate.Views;
using MobileTemplate.WebServices.User;
using Xamarin.Forms;

namespace MobileTemplate.Core
{
    /// <summary>
    /// The class used to create the IoC container of the app.
    /// </summary>
    public abstract class AppSetup
    {
        /// <summary>
        /// Initializes the IoC container and registers the components to be used.
        /// </summary>
        protected AppSetup()
        {
            var builder = new ContainerBuilder();

            this.RegisterDependencies(builder);

            IContainer container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            container.BeginLifetimeScope();
        }

        protected virtual void RegisterDependencies(ContainerBuilder builder)
        {
            this.RegisterViews(builder);
            this.RegisterViewModels(builder);
            this.RegisterWebServices(builder);
            this.RegisterManagers(builder);
            this.RegisterRepositories(builder);
            this.RegisterUtilities(builder);
        }

        private void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<MainView>().Named<Page>(ViewNames.MainView).InstancePerDependency();
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            
            builder.RegisterType<MainViewModel>().InstancePerDependency();
        }

        private void RegisterWebServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserWebService>().As<IUserWebService>().SingleInstance();
        }

        private void RegisterManagers(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<AppDatabase>().As<IAppDatabase>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        }

        private void RegisterUtilities(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        }
    }
}
