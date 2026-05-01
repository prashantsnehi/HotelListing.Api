using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private static List<Country> _countries = new List<Country>
        {
            new Country
            {
                Id = 1,
                Name = "United States",
                Code = "US"
            },
            new Country
            {
                Id = 2,
                Name = "Canada",
                Code = "CA"
            },
            new Country
            {
                Id = 3,
                Name = "United Kingdom",
                Code = "GB"
            }
        };

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await Task.FromResult(_countries);
        }

        public async Task<Country?> GetCountryByIdAsync(int id)
        {
            var country = _countries.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(country);
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (_countries.Any(c => c.Id == country.Id))
            {
                throw new InvalidOperationException("Country with the same Id already exists.");
            }

            _countries.Add(country);
            _countries = _countries.OrderBy(c => c.Id).ToList();
            return await Task.FromResult(country);
        }

        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            var existingCountry = _countries.FirstOrDefault(c => c.Id == id);
            if (existingCountry is null)
            {
                throw new KeyNotFoundException($"Country with Id {id} not found.");
            }

            existingCountry.Name = country.Name;
            existingCountry.Code = country.Code;

            return await Task.FromResult(existingCountry);
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = _countries.FirstOrDefault(c => c.Id == id);
            if (country is null)
            {
                throw new KeyNotFoundException($"Country with Id {id} not found.");
            }

            _countries.Remove(country);
            return await Task.FromResult(true);
        }
    }
}
