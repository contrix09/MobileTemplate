using Autofac;
using MobileTemplate.Core;

namespace MobileTemplate.iOS.Core
{
    public class iOSAppSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            base.RegisterDependencies(builder);

            //Register platform-specific services
        }
    }
}