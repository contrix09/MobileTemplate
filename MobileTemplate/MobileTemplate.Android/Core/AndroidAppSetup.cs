using Autofac;
using MobileTemplate.Core;

namespace MobileTemplate.Droid.Core
{
    public class AndroidAppSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            base.RegisterDependencies(builder);

            //Register platform-specific services
        }
    }
}