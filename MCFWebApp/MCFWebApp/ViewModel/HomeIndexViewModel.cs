using System.ComponentModel.DataAnnotations;

namespace MCFWebApp.ViewModel
{
    public class HomeIndexViewModel
    {
        [Required]
        [Display(Name = "Agreement Number")]
        public string AgreementNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Branch Id")]
        public string BranchId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "No. BPKB")]
        public string BpkbNo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Tanggal BPKB In")]
        [DataType(DataType.Date)]
        public DateTime TanggalBpkbIn { get; set; }

        [Required]
        [Display(Name = "Tanggal BPKB")]
        [DataType(DataType.Date)]
        public DateTime TanggalBpkb { get; set; }

        [Required]
        [Display(Name = "No. Faktur")]
        public string FakturNo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nomor Polisi")]
        public string NomorPolisi { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Lokasi Penyimpanan")]
        public string LokasiPenyimpanan { get; set; } = string.Empty;
    }
}
