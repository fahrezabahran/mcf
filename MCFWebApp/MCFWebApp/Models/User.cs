using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCFWebApp.Models
{
    [Table("ms_user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public long UserId { get; set; }

        [Required]
        [Column("user_name")]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
