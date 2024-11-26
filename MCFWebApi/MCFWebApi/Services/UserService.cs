using MCFWebApi.DTOs;
using MCFWebApi.Models;
using MCFWebApi.Repositories;

namespace MCFWebApi.Services
{
	public class UserService : IUserService
	{
		private readonly IGenericRepository<User> _userRepository;

		public UserService(IGenericRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task CreateUser(UserDto userDto)
		{
			User user = new()
			{
				UserName = userDto.UserName,
				Password = userDto.Password,
				IsActive = false,
			};

			await _userRepository.CreateAsync(user);
		}

		public async Task<User> GetUser(long userid)
		{
			return await _userRepository.GetByIdAsync(userid);
		}

		public async Task<IEnumerable<User>> GetAllUser()
		{
			return await _userRepository.GetAllAsync();
		}

		public async Task UpdateUser(long userid, string password)
		{
			var user = await _userRepository.GetByIdAsync(userid);

			user.Password = password;

			await _userRepository.UpdateAsync(user);
		}

		public async Task DeleteUser(long userid)
		{
			await _userRepository.DeleteAsync(userid);
		}

	}
}
