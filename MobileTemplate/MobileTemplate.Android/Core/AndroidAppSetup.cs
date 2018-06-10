using Autofac;
using MobileTemplate.Core;
using MobileTemplate.Droid.Database;
using MobileTemplate.Repositories.Database;

namespace MobileTemplate.Droid.Core
{
    public class AndroidAppSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            base.RegisterDependencies(builder);

            builder.RegisterType<AndroidDatabaseConnection>().As<IPlatformDatabaseConnection>().SingleInstance();

            //Register platform-specific services
        }
    }
}