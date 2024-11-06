using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelMapApi.Data;
using TravelMapApi.Models;
using TravelMapApi.Repositories.Interface;

namespace TravelMapApi.Repositories
{
    public class PinRepository : IPinRepository
    {
        private readonly TravelMapDbContext _context;

        public PinRepository(TravelMapDbContext context)
        {
            _context = context;
        }

        public async Task<Pin> GetPinByIdAsync(int id)
        {
            return await _context.Pins
                .Include(p => p.Location)
                .Include(p => p.Trips)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pin>> GetAllPinsAsync()
        {
            return await _context.Pins
                .Include(p => p.Location)
                .Include(p => p.Trips)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pin>> GetPinsByLocationIdAsync(int locationId)
        {
            return await _context.Pins
                .Where(p => p.LocationId == locationId)
                .ToListAsync();
        }

        public async Task AddPinAsync(Pin pin)
        {
            _context.Pins.Add(pin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePinAsync(Pin pin)
        {
            _context.Pins.Update(pin);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePinAsync(int id)
        {
            var pin = await GetPinByIdAsync(id);
            if (pin != null)
            {
                _context.Pins.Remove(pin);
                await _context.SaveChangesAsync();
            }
        }
    }
}