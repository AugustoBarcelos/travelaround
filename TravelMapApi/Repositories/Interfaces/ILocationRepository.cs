using TravelMapApi.Models;

namespace TravelMapApi.Repositories.Interface
{
    public interface ILocationRepository
    {
        Task<Location> GetLocationByIdAsync(int id);
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task AddLocationAsync(Location location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(int id);
    }
}