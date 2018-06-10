using System;
using System.Threading.Tasks;
using MobileTemplate.DataContracts.User;
using MobileTemplate.Entities.User;
using MobileTemplate.Repositories.User;
using MobileTemplate.WebServices.User;

namespace MobileTemplate.Managers.User
{
    public class UserManager : IUserManager
    {
        private readonly IUserWebService _userWebService;
        private readonly IUserRepository _userRepository;

        public UserManager(IUserWebService userWebService, IUserRepository _userRepository)
        {
            this._userWebService = userWebService ?? throw new ArgumentNullException();
            this._userRepository = _userRepository ?? throw new ArgumentNullException();
        }

        public async Task<string> LoginUser(UserEntity user)
        {
            var userContract = new UserDataContract
            {
                UserName = user.UserName,
                Password = user.Password
            };

            await this._userWebService.LoginUser(userContract).ConfigureAwait(false);

            this._userRepository.SaveUser(userContract);

            return "Task Finished";
        }
    }
}
