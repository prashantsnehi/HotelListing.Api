using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HotelListingDbContext _context;

        public CountryRepository(HotelListingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries
                .Include(c => c.Hotels)
                .ToListAsync();
        }

        public async Task<Country?> GetCountryByIdAsync(int id)
        {
            return await _context.Countries
                .Include(c => c.Hotels)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (country.Id != 0 && await _context.Countries.AnyAsync(c => c.Id == country.Id))
            {
                throw new InvalidOperationException("Country with the same Id already exists.");
            }

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry is null)
            {
                throw new KeyNotFoundException($"Country with Id {id} not found.");
            }

            existingCountry.Name = country.Name;
            existingCountry.Code = country.Code;

            await _context.SaveChangesAsync();
            return existingCountry;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
            {
                throw new KeyNotFoundException($"Country with Id {id} not found.");
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
