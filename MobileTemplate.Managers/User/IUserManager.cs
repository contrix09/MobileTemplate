using MobileTemplate.Entities.User;
using System.Threading.Tasks;

namespace MobileTemplate.Managers.User
{
    public interface IUserManager
    {
        Task<string> LoginUser(UserEntity user);
    }
}
