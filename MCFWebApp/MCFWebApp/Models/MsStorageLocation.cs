using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCFWebApp.Models
{
    [Table("ms_storage_location")]
    public class MsStorageLocation
    {
        [Key]
        [Column("location_id")]
        [MaxLength(10)]
        public string LocationId { get; set; } = string.Empty;

        [Required]
        [Column("location_name")]
        [MaxLength(100)]
        public string LocationName { get; set; } = string.Empty;
    }
}
