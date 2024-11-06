using TravelMapApi.Models;

namespace TravelMapApi.Services.Interface
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> UserExistsAsync(string email);
    }
}