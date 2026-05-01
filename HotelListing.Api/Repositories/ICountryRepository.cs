using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryByIdAsync(int id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(int id, Country country);
        Task<bool> DeleteCountryAsync(int id);
    }
}
