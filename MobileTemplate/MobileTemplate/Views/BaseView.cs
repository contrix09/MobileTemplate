using CommonServiceLocator;
using MobileTemplate.Helpers;
using MobileTemplate.ViewModels;
using Xamarin.Forms;

namespace MobileTemplate.Views
{
    public class BaseView<TViewModel> : ContentPage, ICleanUp where TViewModel : BaseViewModel
    {
        private object _parameter;

        private bool _viewModelInitialized;

        public BaseView()
        {
            this.ViewModel = ServiceLocator.Current.GetInstance<TViewModel>();
        }

        public BaseView(object parameter)
        {
            this.ViewModel = ServiceLocator.Current.GetInstance<TViewModel>();
            this._parameter = parameter;
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
            System.Diagnostics.Debug.WriteLine("Cleaning up view");
            this.ViewModel.CleanUp();
            this.BindingContext = this.ViewModel = null;
            this.Content = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(!this._viewModelInitialized)
            {
                if(this.BindingContext == null)
                {
                    this.BindingContext = this.ViewModel;
                }

                if(this._parameter != null)
                {
                    this.ViewModel.Init(this._parameter);
                }

                this._viewModelInitialized = true;
            }
        }
    }
}