using MCFWebApi.DTOs;
using MCFWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MCFWebApi.Controllers
{
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _service;

		public LoginController(ILoginService service)
		{
			_service = service;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> LoginUser([FromBody] UserDto userDto)
		{
			if (!ModelState.IsValid)
			{
				throw new Exception("Bad Request Data");
			}

			var result = await _service.ProcessLoginUser(userDto.UserName, userDto.Password);
			if (result == null)
			{
				throw new Exception("Internal Data Error");
			}

			return Ok(new { success = true, status_code = StatusCodes.Status200OK, message = "Login Success", data = result });
		}
	}
}
