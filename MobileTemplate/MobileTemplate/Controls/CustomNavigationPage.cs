﻿using MobileTemplate.Helpers;
using System.Linq;
using Xamarin.Forms;

namespace MobileTemplate.Controls
{
    public class CustomNavigationPage : NavigationPage, ICleanUp
    {
        public CustomNavigationPage() { }

        public CustomNavigationPage(Page root) : base(root)
        {
            this.Popped += this.CustomNavigationPage_Popped;
        }

        /// <summary>
        /// Method to dispose this <see cref="NavigationPage"/> and its <see cref="NavigationPage.RootPage"/>.
        /// </summary>
        public void CleanUp()
        {
            var currentNavigationRootPage = this.Navigation.NavigationStack.FirstOrDefault() as ICleanUp;
            currentNavigationRootPage.CleanUp();
            this.Popped -= this.CustomNavigationPage_Popped;
        }

        private void CustomNavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            if (e.Page is ICleanUp view)
            {
                view.CleanUp();
            }
        }
    }
}
