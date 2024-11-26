using MCFWebApi.Models;
using MCFWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCFWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StorageController : ControllerBase
	{
		private readonly IStorageService _storageService;
		public StorageController(IStorageService storageService)
		{
			_storageService = storageService;
		}

		// GET: api/<StorageLocationController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var users = await _storageService.GetAllStorageLocation();

			return Ok(users);
		}

		// GET api/<StorageLocationController>/5
		[HttpGet("{locationId}")]
		public async Task<IActionResult> Get(string locationId)
		{
			var user = await _storageService.GetStorageLocation(locationId);

			return Ok(user);
		}

		// POST api/<StorageLocationController>
		[HttpPost]
		public async Task<IActionResult> Post(StorageLocation storageLocation)
		{
			await _storageService.CreateStorageLocation(storageLocation);

			return Ok();
		}

		// PUT api/<StorageLocationController>/5
		[HttpPut("{locationId}")]
		public async Task<IActionResult> Put(string locationId, [FromBody] string locationName)
		{
			await _storageService.UpdateStorageLocation(locationId, locationName);

			return Ok();
		}

		// DELETE api/<StorageLocationController>/5
		[HttpDelete("{locationId}")]
		public async Task<IActionResult> Delete(string locationId)
		{
			await _storageService.DeleteStorageLocation(locationId);

			return Ok();
		}
	}
}
