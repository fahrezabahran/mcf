using MCFWebApi.DTOs;
using MCFWebApi.Models;
using MCFWebApi.Repositories;

namespace MCFWebApi.Services
{
	public class BpkbService : IBpkbService
	{
		private readonly IGenericRepository<Bpkb> _BpkbService;

		public BpkbService(IGenericRepository<Bpkb> BpkbService)
		{
			_BpkbService = BpkbService;
		}

		public async Task CreateBpkb(BpkbDto bpkbDto)
		{
			var bpkb = new Bpkb()
			{
				AgreementNumber = bpkbDto.AgreementNumber,
				BranchId = bpkbDto.BranchId,
				BpkbNo = bpkbDto.BpkbNo,
				BpkbDate = bpkbDto.BpkbDate,
				BpkbDateIn = bpkbDto.BpkbDateIn,
				FakturNo = bpkbDto.FakturNo,
				FakturDate = bpkbDto.FakturDate,
				PoliceNo = bpkbDto.PoliceNo,
				LocationId = bpkbDto.LocationId,
				CreatedBy = bpkbDto.UserId,
				CreatedOn = DateTime.Now,
				LastUpdatedBy = bpkbDto.UserId,
				LastUpdatedOn = DateTime.Now,
			};

			await _BpkbService.CreateAsync(bpkb);
		}

		public async Task<Bpkb> GetBpkb(string agreementNumber)
		{
			return await _BpkbService.GetByIdAsync(agreementNumber);
		}

		public async Task<IEnumerable<Bpkb>> GetAllBpkb()
		{
			return await _BpkbService.GetAllAsync();
		}

		public async Task UpdateBpkb(string agreementNumber, BpkbDto bpkbDto)
		{
			var bpkb = await _BpkbService.GetByIdAsync(agreementNumber);

			bpkb.AgreementNumber = bpkbDto.AgreementNumber;
			bpkb.BranchId = bpkbDto.BranchId;
			bpkb.BpkbNo = bpkbDto.BpkbNo;
			bpkb.BpkbDate = bpkbDto.BpkbDate;
			bpkb.BpkbDateIn = bpkbDto.BpkbDateIn;
			bpkb.FakturNo = bpkbDto.FakturNo;
			bpkb.FakturDate = bpkbDto.FakturDate;
			bpkb.PoliceNo = bpkbDto.PoliceNo;
			bpkb.BpkbDateIn = bpkbDto.BpkbDateIn;
			bpkb.LocationId = bpkbDto.LocationId;
			bpkb.LastUpdatedBy = bpkbDto.UserId;
			bpkb.LastUpdatedOn = DateTime.Now;

			await _BpkbService.UpdateAsync(bpkb);
		}

		public async Task DeleteBpkb(string agreementNumber)
		{
			await _BpkbService.DeleteAsync(agreementNumber);
		}
	}
}
