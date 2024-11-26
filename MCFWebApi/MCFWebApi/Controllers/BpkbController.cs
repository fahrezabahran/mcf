using MCFWebApi.DTOs;
using MCFWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MCFWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BpkbController : ControllerBase
	{
		private readonly IBpkbService _bpkbService;
		public BpkbController(IBpkbService bpkbService)
		{
			_bpkbService = bpkbService;
		}

		// GET: api/<BpkbController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var bpkbs = await _bpkbService.GetAllBpkb();

			return Ok(bpkbs);
		}

		// GET api/<BpkbController>/5
		[HttpGet("{agreementNumber}")]
		public async Task<IActionResult> Get(string agreementNumber)
		{
			var user = await _bpkbService.GetBpkb(agreementNumber);

			return Ok(user);
		}

		// POST api/<BpkbController>
		[HttpPost]
		public async Task<IActionResult> Post(BpkbDto bpkbDto)
		{
			await _bpkbService.CreateBpkb(bpkbDto);

			return Ok();
		}

		// PUT api/<BpkbController>/5
		[HttpPut("{agreementNumber}")]
		public async Task<IActionResult> Put(string agreementNumber, BpkbDto bpkbDto)
		{
			await _bpkbService.UpdateBpkb(agreementNumber, bpkbDto);

			return Ok();
		}

		// DELETE api/<BpkbController>/5
		[HttpDelete("{agreementNumber}")]
		public async Task<IActionResult> Delete(string agreementNumber)
		{
			await _bpkbService.DeleteBpkb(agreementNumber);

			return Ok();
		}
	}
}
