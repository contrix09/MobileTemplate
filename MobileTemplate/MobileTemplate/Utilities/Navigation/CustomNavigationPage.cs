using MobileTemplate.Helpers;
using Xamarin.Forms;

namespace MobileTemplate.Utilities.Navigation
{
    public class CustomNavigationPage : NavigationPage, ICleanUp
    {
        public CustomNavigationPage() { }

        public CustomNavigationPage(Page root) : base(root)
        {
            this.Popped += this.CustomNavigationPage_Popped;
        }

        /// <summary>
        /// Method to clean this <see cref="NavigationPage"/> and its <see cref="NavigationPage.RootPage"/>.
        /// </summary>
        public void CleanUp()
        {
            foreach (ICleanUp view in this.Navigation.NavigationStack)
            {
                System.Diagnostics.Debug.WriteLine("Cleaning up: " + view);
                view.CleanUp();
            }

            this.Popped -= this.CustomNavigationPage_Popped;
        }

        private void CustomNavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            if (e.Page is ICleanUp view)
            {
                System.Diagnostics.Debug.WriteLine("Cleaning up: " + view);
                view.CleanUp();
            }
        }
    }
}
