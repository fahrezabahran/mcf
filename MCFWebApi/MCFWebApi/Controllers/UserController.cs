using MCFWebApi.DTOs;
using MCFWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCFWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		// GET: api/<UserController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var users = await _userService.GetAllUser();

			return Ok(users);
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
		{
			var user = await _userService.GetUser(id);

			return Ok(user);
		}

		// POST api/<UserController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserDto userDto)
		{
			await _userService.CreateUser(userDto);

			return Ok();
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(long id, [FromBody] string password)
		{
			await _userService.UpdateUser(id, password);

			return Ok();
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _userService.DeleteUser(id);

			return Ok();
		}
	}
}
