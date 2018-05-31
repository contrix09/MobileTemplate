using MobileTemplate.Helpers;
using MobileTemplate.Managers.User;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTemplate.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IUserManager _userManager;

        public MainViewModel(IUserManager userManager)
        {
            this._userManager = userManager ?? throw new ArgumentNullException();
        }

        private string _welcomeText;
        public string WelcomeText
        {
            get => this._welcomeText;
            set => Set(ref this._welcomeText, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => this._isBusy;
            set => Set(ref this._isBusy, value);
        }

        public ICommand LabelTapCommand => new AsyncCommand(this.LoginAsync, () => !this.IsBusy);

        public override Task Init(object parameter)
        {
            this.WelcomeText = this.InitParameter.ToString();

            return base.Init(parameter);
        }

        private async Task LoginAsync()
        {
            System.Diagnostics.Debug.WriteLine("Task started");

            this.IsBusy = true;

            await this._userManager.LoginUser(null);
            await Task.Delay(5000);

            System.Diagnostics.Debug.WriteLine("Task finished");

            this.IsBusy = false;
        }
    }
}
