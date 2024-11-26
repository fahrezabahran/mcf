using MCFWebApi.Models;

namespace MCFWebApi.Services
{
	public interface ILoginService
	{
		Task<User> ProcessLoginUser(string userName, string password);
	}
}
