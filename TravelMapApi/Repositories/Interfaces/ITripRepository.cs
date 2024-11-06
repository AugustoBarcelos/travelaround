using TravelMapApi.Models;

namespace TravelMapApi.Repositories.Interface
{
    public interface ITripRepository
    {
        Task<Trip> GetTripByIdAsync(int id);
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Task<IEnumerable<Trip>> GetTripsByUserIdAsync(int userId);
        Task AddTripAsync(Trip trip);
        Task UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(int id);
    }
}