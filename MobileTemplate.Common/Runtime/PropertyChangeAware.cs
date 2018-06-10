﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileTemplate.Common.Runtime
{
    /// <summary>
    /// An abstract class that implements the <see cref="INotifyPropertyChanged"/> interface. It provides the method <see cref="PropertyChangeAware.Set{T}(ref T, T, string)"/> 
    /// which will raise the <see cref="INotifyPropertyChanged.PropertyChanged"/> event when there is any change of an inheriting class' properties.
    ///</summary>
    public abstract class PropertyChangeAware : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when any properties on this instance have changed by using the <see cref="PropertyChangeAware.Set{T}(ref T, T, string)"/> method.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to change a property's value. This will also call the <see cref="OnPropertyChanged(string)" /> method.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The field containing the current property's value.</param>
        /// <param name="newValue">The new value to be assigned.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void Set<T>(ref T field, T newValue = default(T), [CallerMemberName]string propertyName = null)
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
        /// Method called to raise the <see cref="INotifyPropertyChanged.PropertyChanged" /> event if there was a change in any property.
        /// </summary>
        /// <param name="propertyName">The name of the property who's value has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
