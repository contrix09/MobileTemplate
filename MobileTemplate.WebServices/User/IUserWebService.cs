using MobileTemplate.DataContracts.User;
using System.Threading.Tasks;

namespace MobileTemplate.WebServices.User
{
    public interface IUserWebService
    {
        Task LoginUser(UserDataContract user);
    }
}
