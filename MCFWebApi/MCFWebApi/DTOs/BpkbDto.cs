using System.ComponentModel.DataAnnotations;

namespace MCFWebApi.DTOs
{
	public class BpkbDto
	{
		[Required]
		public string AgreementNumber { get; set; } = string.Empty;

		[Required]
		public string BranchId { get; set; } = string.Empty;

		[Required]
		public string BpkbNo { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Date)]
		public DateTime BpkbDateIn { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BpkbDate { get; set; }

		[Required]
		public string FakturNo { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Date)]
		public DateTime FakturDate { get; set; }

		[Required]
		public string PoliceNo { get; set; } = string.Empty;

		[Required]
		public string LocationId { get; set; } = string.Empty;

		[Required]
		public string UserId { get; set; } = string.Empty;

	}
}
