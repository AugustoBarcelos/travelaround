using Microsoft.EntityFrameworkCore;
using TravelMapApi.Data;
using TravelMapApi.Models;
using TravelMapApi.Repositories.Interface;

namespace TravelMapApi.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TravelMapDbContext _context;

        public LocationRepository(TravelMapDbContext context)
        {
            _context = context;
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await GetLocationByIdAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}