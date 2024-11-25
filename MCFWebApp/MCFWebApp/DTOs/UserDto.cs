using System.ComponentModel.DataAnnotations;

namespace MCFWebApp.DTOs
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
