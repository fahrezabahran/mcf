using MCFWebApi.Models;
using MCFWebApi.Repositories;

namespace MCFWebApi.Services
{
	public class StorageService : IStorageService
	{
		private readonly IGenericRepository<StorageLocation> _storageLocationService;

		public StorageService(IGenericRepository<StorageLocation> storageLocationService)
		{
			_storageLocationService = storageLocationService;
		}

		public async Task CreateStorageLocation(StorageLocation storageLocation)
		{
			await _storageLocationService.CreateAsync(storageLocation);
		}

		public async Task<StorageLocation> GetStorageLocation(string locationId)
		{
			return await _storageLocationService.GetByIdAsync(locationId);
		}

		public async Task<IEnumerable<StorageLocation>> GetAllStorageLocation()
		{
			return await _storageLocationService.GetAllAsync();
		}

		public async Task UpdateStorageLocation(string locationId, string locationName)
		{
			var storageLocation = await _storageLocationService.GetByIdAsync(locationId);

			storageLocation.LocationName = locationName;

			await _storageLocationService.UpdateAsync(storageLocation);
		}

		public async Task DeleteStorageLocation(string locationId)
		{
			await _storageLocationService.DeleteAsync(locationId);
		}
	}
}
