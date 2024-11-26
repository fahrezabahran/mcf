using MCFWebApi.DTOs;
using MCFWebApi.Models;

namespace MCFWebApi.Services
{
	public interface IUserService
	{
		Task CreateUser(UserDto userDto);
		Task<User> GetUser(long userid);
		Task<IEnumerable<User>> GetAllUser();
		Task UpdateUser(long userid, string password);
		Task DeleteUser(long userid);
	}
}
