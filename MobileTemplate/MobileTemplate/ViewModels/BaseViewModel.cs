using CommonServiceLocator;
using MobileTemplate.Helpers;
using MobileTemplate.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileTemplate.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, ICleanUp
    {
        /// <summary>
        /// Raised when there is any changes in this viewmodel's properties using the <see cref="BaseViewModel.Set{T}(ref T, T, string)"/> method.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The Navigation Service.
        /// </summary>
        protected INavigationService Navigation => ServiceLocator.Current.GetInstance<INavigationService>();

        /// <summary>
        /// Method to change any property's value. This will also call the <see cref="BaseViewModel.OnPropertyChanged(string)" /> method.
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
        /// Method for view model initialization. This will be called if the last <see cref="NavigationService.NavigateAsync(string, object, bool)"/> or <see cref="NavigationService.NavigateModalAsync(string, object, bool)"/> action contains a parameter.
        /// </summary>
        /// <param name="parameter">The parameter passed for initialization.</param>
        public virtual void Init(object parameter) { }

        /// <summary>
        /// Method called to raise the <see cref="INotifyPropertyChanged.PropertyChanged" /> event if there was a change in any property.
        /// </summary>
        /// <param name="propertyName">The name of the property who's value has changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Method to clean up objects in this view model.
        /// </summary>
        public virtual void CleanUp()
        {
            System.Diagnostics.Debug.WriteLine("Cleaning up view model");
        }
    }
}
