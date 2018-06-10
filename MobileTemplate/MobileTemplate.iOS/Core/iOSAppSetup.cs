using Autofac;
using MobileTemplate.Core;
using MobileTemplate.iOS.Database;
using MobileTemplate.Repositories.Database;

namespace MobileTemplate.iOS.Core
{
    public class iOSAppSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            base.RegisterDependencies(builder);

            builder.RegisterType<iOSDatabaseConnection>().As<IPlatformDatabaseConnection>().SingleInstance();

            //Register platform-specific services
        }
    }
}