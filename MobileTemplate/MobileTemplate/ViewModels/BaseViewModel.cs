using CommonServiceLocator;
using MobileTemplate.Helpers;
using MobileTemplate.Utilities;

namespace MobileTemplate.ViewModels
{
    public abstract class BaseViewModel : PropertyChangeAware, ICleanUp
    {
        /// <summary>
        /// The Navigation Service.
        /// </summary>
        protected INavigationService Navigation => ServiceLocator.Current.GetInstance<INavigationService>();

        /// <summary>
        /// Method for view model initialization.
        /// </summary>
        /// <param name="parameter">The parameter, if any, that will be passed during this view model's initialization.</param>
        public virtual void Init(object parameter = null) { }

        /// <summary>
        /// Method to clean up objects in this view model.
        /// </summary>
        public virtual void CleanUp() { }
    }
}
