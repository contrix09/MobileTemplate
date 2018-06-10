using MobileTemplate.DataContracts.User;

namespace MobileTemplate.Repositories.User
{
    public interface IUserRepository
    {
        void SaveUser(UserDataContract user);
    }
}
