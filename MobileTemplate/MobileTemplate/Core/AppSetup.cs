using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MobileTemplate.Managers.User;
using MobileTemplate.Services;
using MobileTemplate.ViewModels;
using MobileTemplate.WebServices.User;

namespace MobileTemplate.Core
{
    public abstract class AppSetup
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            this.RegisterDependencies(builder);

            IContainer container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            return container;
        }

        protected virtual void RegisterDependencies(ContainerBuilder builder)
        {
            this.RegisterViewModels(builder);
            this.RegisterWebServices(builder);
            this.RegisterManagers(builder);
            this.RegisterUtilities(builder);
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

        private void RegisterUtilities(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        }
    }
}
