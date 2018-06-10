using MobileTemplate.DataContracts.User;
using MobileTemplate.Repositories.Database;

namespace MobileTemplate.Repositories.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IAppDatabase appDatabase) : base(appDatabase) { }

        public void SaveUser(UserDataContract user)
        {
            this.Db.InsertItem(user);
        }
    }
}
