using CommonServiceLocator;
using MobileTemplate.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MobileTemplate.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when there is any changes in this viewmodel's properties using the Set() method.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The object containing the needed parameter during the viewmodel's initialization.
        /// </summary>
        public object InitParameter { get; set; }

        /// <summary>
        /// The Navigation Service.
        /// </summary>
        protected INavigationService Navigation => ServiceLocator.Current.GetInstance<INavigationService>();

        /// <summary>
        /// Called to change any property's value.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The field containing the current property's value.</param>
        /// <param name="newValue">The new value to be assigned.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected virtual void Set<T>(ref T field, T newValue = default(T), [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, default(T)))
            {
                if (!field.Equals(newValue))
                {
                    field = newValue;
                    this.OnPropertyChanged(propertyName);
                }
            }

            else if (!EqualityComparer<T>.Default.Equals(newValue, default(T)))
            {
                field = newValue;
                this.OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Overridable method for view model initialization.
        /// </summary>
        /// <param name="parameter">The parameter passed for initialization.</param>
        public virtual Task Init(object parameter)
        {
            return Task.FromResult(default(object));
        }

        /// <summary>
        /// Method called for any change in a property's value.
        /// </summary>
        /// <param name="propertyName">The name of the property who's value has changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
