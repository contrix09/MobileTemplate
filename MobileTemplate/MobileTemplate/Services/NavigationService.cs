using MobileTemplate.ViewModels;
using MobileTemplate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTemplate.Services
{
    public class NavigationService : INavigationService
    {
        #region Fields

        private static readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();

        private readonly object _sync = new object();

        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the current visible Page key
        /// </summary>
        public string CurrentPageKey
        {
            get
            {
                lock (this._sync)
                {
                    if (this.CurrentNavigationPage?.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = this.CurrentNavigationPage.CurrentPage.GetType();

                    return this._pagesByKey.ContainsValue(pageType)
                        ? this._pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        #endregion Properties

        #region Constructor

        public NavigationService()
        {
            this.Configure("MainView", typeof(MainView));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Adds a Page in the Navigation Stack
        /// </summary>
        /// <param name="pageKey">The key to identify a specific Page</param>
        /// <param name="pageType">The type of the Page</param>
        public void Configure(string pageKey, Type pageType)
        {
            lock (this._sync)
            {
                if (this._pagesByKey.ContainsKey(pageKey))
                {
                    this._pagesByKey[pageKey] = pageType;
                }
                else
                {
                    this._pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        /// <summary>
        /// Sets the Root Page of a new Navigation Stack
        /// </summary>
        /// <param name="rootPageKey">The key to identify the Root Page</param>
        public void SetRootPage(string rootPageKey, object parameter = null)
        {
            var rootPage = GetPage(rootPageKey) ?? throw new NullReferenceException($"The root page {rootPageKey} was null");
            var mainPage = new NavigationPage(rootPage);
            _navigationPageStack.Clear();
            _navigationPageStack.Push(mainPage);

            if (parameter != null)
            {
                (rootPage.BindingContext as BaseViewModel).InitParameter = parameter;
            }

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
        }

        /// <summary>
        /// Initializes and retrieves a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the page to be retrieved</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be retrieved</param>
        private Page GetPage(string pageKey)
        {
            lock (this._sync)
            {
                if (!this._pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException($"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                }

                var type = this._pagesByKey[pageKey];
                var constructor = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault();

                return constructor?.Invoke(null) as Page ?? throw new InvalidOperationException("No suitable constructor found for page " + pageKey);
            }
        }

        #endregion Methods
    }
}