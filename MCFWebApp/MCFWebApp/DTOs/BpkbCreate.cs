using System.ComponentModel.DataAnnotations;

namespace MCFWebApp.DTOs
{
    public class BpkbCreate
    {
        [Required]
        public string AgreementNumber { get; set; }
        [Required]
        public string BranchId { get; set; }
        [Required]
        public string BpkbNo { get; set; }
        [Required]
        public DateTime BpkbDateIn { get; set; }
        [Required]
        public DateTime BpkbDate { get; set; }
        [Required]
        public string FakturNo { get; set; }
        [Required]
        public DateTime FakturDate { get; set; }
        [Required]
        public string PoliceNo { get; set; }
        [Required]
        public string LokasiPenyimpanan { get; set; }
    }
}
