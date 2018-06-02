using MobileTemplate.Common;
using MobileTemplate.Helpers.Commands;
using MobileTemplate.Managers.User;
using System;
using System.Threading.Tasks;

namespace MobileTemplate.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private readonly IUserManager _userManager;

        #endregion

        #region Constructor

        public MainViewModel(IUserManager userManager)
        {
            this._userManager = userManager ?? throw new ArgumentNullException();
        }

        #endregion

        #region Properties

        private string _welcomeText;
        public string WelcomeText
        {
            get => this._welcomeText;
            set => Set(ref this._welcomeText, value);
        }

        #endregion Properties

        #region Commands

        public AsyncCommand LabelTapCommand => new AsyncCommand(this.LoginAsync);

        #endregion

        #region Methods

        public override void Init(object parameter)
        {
            this.WelcomeText = parameter.ToString();
        }

        private async Task LoginAsync(object arg)
        {
            //System.Diagnostics.Debug.WriteLine(arg.ToString());

            //await this._userManager.LoginUser(null);
            //await Task.Delay(5000);

            //System.Diagnostics.Debug.WriteLine("Task finished");

            await this.Navigation.NavigateAsync(ViewNames.MAIN_VIEW, "Second Page");
        }

        #endregion
    }
}
