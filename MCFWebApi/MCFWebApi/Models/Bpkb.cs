using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCFWebApi.Models
{
	[Table("tr_bpkb")]
	public class Bpkb
	{
		[Key]
		[Column("agreement_number")]
		[Required]
		public string AgreementNumber { get; set; } = string.Empty;

		[Column("bpkb_no")]
		[Required]
		public string BpkbNo { get; set; } = string.Empty;

		[Column("branch_id")]
		[Required]
		public string BranchId { get; set; } = string.Empty;

		[Column("bpkb_date")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime BpkbDate { get; set; }

		[Column("faktur_no")]
		[Required]
		public string FakturNo { get; set; } = string.Empty;

		[Column("faktur_date")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime FakturDate { get; set; }

		[Column("location_id")]
		[Required]
		public string LocationId { get; set; } = string.Empty;

		[Column("police_no")]
		[Required]
		public string PoliceNo { get; set; } = string.Empty;

		[Column("bpkb_date_in")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime BpkbDateIn { get; set; }

		[Column("created_by")]
		[Required]
		public string CreatedBy { get; set; } = string.Empty;

		[Column("created_on")]
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime CreatedOn { get; set; }

		[Column("last_updated_by")]
		[Required]
		public string LastUpdatedBy { get; set; } = string.Empty;

		[Column("last_updated_on")]
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime LastUpdatedOn { get; set; }
	}
}
