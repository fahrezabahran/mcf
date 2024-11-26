using MCFWebApi.DTOs;
using MCFWebApi.Models;

namespace MCFWebApi.Services
{
	public interface IBpkbService
	{
		Task CreateBpkb(BpkbDto bpkbDto);
		Task<Bpkb> GetBpkb(string agreementNumber);
		Task<IEnumerable<Bpkb>> GetAllBpkb();
		Task UpdateBpkb(string agreementNumber, BpkbDto bpkbDto);
		Task DeleteBpkb(string agreementNumber);
	}
}
