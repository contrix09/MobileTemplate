using CommonServiceLocator;
using MobileTemplate.ViewModels;
using Xamarin.Forms;

namespace MobileTemplate.Views
{
    public class BaseView<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        public TViewModel ViewModel { get; }

        private bool _viewModelInitialized;

        public BaseView()
        {
            this.ViewModel = ServiceLocator.Current.GetInstance<TViewModel>() ?? throw new Autofac.Core.DependencyResolutionException($"Cannot get the instance of the view model {typeof(TViewModel)} from the IoC container.");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!this._viewModelInitialized && this.ViewModel.InitParameter != null)
            {
                await this.ViewModel.Init(this.ViewModel.InitParameter); // Call Init of view model with parameters after the view appeared.
                this._viewModelInitialized = true;
            }
        }
    }
}