using Autofac;

namespace MobileTemplate.Core
{
    /// <summary>
    /// Static class for accessing the IoC container of the application.
    /// </summary>
    public static class AppContainer
    {
        /// <summary>
        /// The IoC container object which creates, wires dependencies and manages lifetime for a set of components.
        /// </summary>
        public static IContainer Container { get; set; }
    }
}
