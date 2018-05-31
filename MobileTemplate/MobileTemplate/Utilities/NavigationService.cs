using CommonServiceLocator;
using MobileTemplate.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTemplate.Utilities
{
    public class NavigationService : INavigationService
    {
        #region Fields

        private static readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the current visible Page key
        /// </summary>
        public string CurrentPageKey { get; set; }

        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the Root Page of a new Navigation Stack
        /// </summary>
        /// <param name="rootPageKey">The key to identify the Root Page</param>
        public void SetRootPage(string rootPageKey, object parameter = null)
        {
            var rootPage = GetPage(rootPageKey);
            var mainPage = new NavigationPage(rootPage);
            _navigationPageStack.Clear();
            _navigationPageStack.Push(mainPage);

            if (parameter != null)
            {
                (rootPage.BindingContext as BaseViewModel).InitParameter = parameter;
            }

            this.CurrentPageKey = rootPageKey;

            Application.Current.MainPage = mainPage;
        }

        /// <summary>
        /// Navigate back to the most recent Page
        /// </summary>
        public async Task GoBack()
        {
            var navigationStack = this.CurrentNavigationPage.Navigation;
            if (navigationStack.NavigationStack.Count > 1)
            {
                await this.CurrentNavigationPage.PopAsync();
                return;
            }

            if (_navigationPageStack.Count > 1)
            {
                _navigationPageStack.Pop();
                await this.CurrentNavigationPage.Navigation.PopModalAsync();
                return;
            }

            await this.CurrentNavigationPage.PopAsync();
        }

        /// <summary>
        /// Navigate to a Page displayed modally
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        public async Task NavigateModalAsync(string pageKey, bool animated = true)
        {
            await NavigateModalAsync(pageKey, null, animated);
        }

        /// <summary>
        /// Navigate to a Page displayed modally
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be navigated to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        public async Task NavigateModalAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey);
            var modalNavigationPage = new NavigationPage(page);
            NavigationPage.SetHasNavigationBar(page, false);
            _navigationPageStack.Push(modalNavigationPage);

            if (parameter != null)
            {
                (page.BindingContext as BaseViewModel).InitParameter = parameter;
            }

            await this.CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);

            this.CurrentPageKey = pageKey;
        }

        /// <summary>
        /// Navigate to a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        public async Task NavigateAsync(string pageKey, bool animated = true)
        {
            await NavigateAsync(pageKey, null, animated);
        }

        /// <summary>
        /// Navigate to a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be navigated to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        public async Task NavigateAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey);

            if (parameter != null)
            {
                (page.BindingContext as BaseViewModel).InitParameter = parameter;
            }

            await this.CurrentNavigationPage.Navigation.PushAsync(page, animated);

            this.CurrentPageKey = pageKey;
        }

        /// <summary>
        /// Initializes and retrieves a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the page to be retrieved</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be retrieved</param>
        private Page GetPage(string pageKey)
        {
            return ServiceLocator.Current.GetInstance<Page>(pageKey);
        }

        #endregion Methods
    }
}