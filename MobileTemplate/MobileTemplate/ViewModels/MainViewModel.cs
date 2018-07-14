﻿using MobileTemplate.Common;
using MobileTemplate.Helpers.Commands;
using MobileTemplate.Managers.User;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            get => _welcomeText;
            set => Set(ref _welcomeText, value);
        }

        #endregion Properties

        #region Commands

        public AsyncCommand LabelTapCommand => new AsyncCommand(this.LoginAsync);

        #endregion

        #region Methods

        public override void Init(object parameter = null)
        {
            this.WelcomeText = parameter?.ToString();
        }

        private async Task LoginAsync(object arg)
        {
            await this.Navigation.NavigateAsync(ViewNames.MainView, arg);
        }

        #endregion
    }
}
