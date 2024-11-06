using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelMapApi.Data;
using TravelMapApi.Models;
using TravelMapApi.Repositories.Interface;

namespace TravelMapApi.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly TravelMapDbContext _context;

        public TripRepository(TravelMapDbContext context)
        {
            _context = context;
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.User)  
                .Include(t => t.Pins)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips
                .Include(t => t.User)
                .Include(t => t.Pins)
                .ToListAsync();
        }

        public async Task<IEnumerable<Trip>> GetTripsByUserIdAsync(int userId)
        {
            return await _context.Trips
                .Include(t => t.Pins)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripAsync(int id)
        {
            var trip = await GetTripByIdAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }
}