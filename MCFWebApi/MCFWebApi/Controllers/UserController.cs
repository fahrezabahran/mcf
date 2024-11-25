using MCFWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using MCFWebApi.DTOs;

namespace MCFWebApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
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
