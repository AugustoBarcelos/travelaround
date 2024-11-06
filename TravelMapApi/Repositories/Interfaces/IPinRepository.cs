using TravelMapApi.Models;

namespace TravelMapApi.Repositories.Interface
{
    public interface IPinRepository
    {
        Task<Pin> GetPinByIdAsync(int id);
        Task<IEnumerable<Pin>> GetAllPinsAsync();
        Task<IEnumerable<Pin>> GetPinsByLocationIdAsync(int locationId);
        Task AddPinAsync(Pin pin);
        Task UpdatePinAsync(Pin pin);
        Task DeletePinAsync(int id);
    }
}