using Autofac;
using MobileTemplate.Core;
using Xamarin.Forms.Platform.Android;

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