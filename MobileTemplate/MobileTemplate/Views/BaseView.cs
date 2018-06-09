using CommonServiceLocator;
using MobileTemplate.Helpers;
using MobileTemplate.Utilities;
using MobileTemplate.ViewModels;
using Xamarin.Forms;

namespace MobileTemplate.Views
{
    public class BaseView<TViewModel> : ContentPage, ICleanUp where TViewModel : BaseViewModel
    {
        private bool _viewModelInitialized;

        public BaseView()
        {
            this.ViewModel = ServiceLocator.Current.GetInstance<TViewModel>();
        }

        /// <summary>
        /// Gets the object that is currently bound as this view's <see cref="BindableObject.BindingContext"/>.
        /// </summary>
        public TViewModel ViewModel { get; private set; }


        /// <summary>
        /// Method to clean up objects in this view by setting its <see cref="BaseView{TViewModel}.ViewModel"/>, <see cref="BindableObject.BindingContext"/> and <see cref="ContentPage.Content"/> to <see cref="null"/>.
        /// </summary>
        public virtual void CleanUp()
        {
            this.ViewModel.CleanUp();
            this.BindingContext = this.ViewModel = null;
            this.Content = null;
        }

        protected override void OnAppearing()
        {
            if(!this._viewModelInitialized)
            {
                if(this.BindingContext == null)
                {
                    this.BindingContext = this.ViewModel;
                }

                this._viewModelInitialized = true;
            }

            base.OnAppearing();
        }
    }
}