using System.Threading.Tasks;
using TravelMapApi.Models;

namespace TravelMapApi.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email); 
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}