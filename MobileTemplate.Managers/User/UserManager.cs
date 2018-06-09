﻿using System.Threading.Tasks;
using MobileTemplate.DataContracts.User;
using MobileTemplate.Entities.User;
using MobileTemplate.WebServices.User;

namespace MobileTemplate.Managers.User
{
    public class UserManager : IUserManager
    {
        private readonly IUserWebService _userWebService;

        public UserManager(IUserWebService userWebService)
        {
            this._userWebService = userWebService;
        }

        public async Task<string> LoginUser(UserEntity user)
        {
            var userContract = new UserDataContract
            {
                UserName = user?.UserName,
                Password = user?.Password
            };

            await this._userWebService.LoginUser(userContract);

            return "Task Finished";
        }
    }
}
