using MCFWebApi.Models;

namespace MCFWebApi.Services
{
	public interface IStorageService
	{
		Task CreateStorageLocation(StorageLocation storageLocation);
		Task<StorageLocation> GetStorageLocation(string locationId);
		Task<IEnumerable<StorageLocation>> GetAllStorageLocation();
		Task UpdateStorageLocation(string locationId, string locationName);
		Task DeleteStorageLocation(string locationId);

	}
}
