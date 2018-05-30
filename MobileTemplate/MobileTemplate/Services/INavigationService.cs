﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTemplate.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Adds a Page in the Navigation Stack
        /// </summary>
        /// <param name="pageKey">The key to identify a specific Page</param>
        /// <param name="pageType">The type of the Page</param>
        void Configure(string pageKey, Type pageType);

        /// <summary>
        /// Sets the Root Page of a new Navigation Stack
        /// </summary>
        /// <param name="rootPageKey">The key to identify the Root Page</param>
        void SetRootPage(string rootPageKey, object parameter = null);

        /// <summary>
        /// Navigate back to the most recent Page
        /// </summary>
        Task GoBack();

        /// <summary>
        /// Navigate to a Page displayed modally
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        Task NavigateModalAsync(string pageKey, bool animated = true);

        /// <summary>
        /// Navigate to a Page displayed modally
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be navigated to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        Task NavigateModalAsync(string pageKey, object parameter, bool animated = true);

        /// <summary>
        /// Navigate to a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        Task NavigateAsync(string pageKey, bool animated = true);

        /// <summary>
        /// Navigate to a Page
        /// </summary>
        /// <param name="pageKey">The key to identify the Page to navigate to</param>
        /// <param name="parameter">The parameter to be passed to the Page that will be navigated to</param>
        /// <param name="animated">Sets whether the navigation will be animated</param>
        Task NavigateAsync(string pageKey, object parameter, bool animated = true);
    }
}
