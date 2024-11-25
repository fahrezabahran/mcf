using MCFWebApi.Models;

namespace MCFWebApi.Services
{
    public interface IUserService
    {
        Task<User> ProcessLoginUser(string userName, string password);
    }
}
