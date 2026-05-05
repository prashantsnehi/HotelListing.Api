using HotelListing.Api.Data;
using HotelListing.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController(ICountryRepository _countryRepository) : ControllerBase
    {
        // private readonly ICountryRepository _countryRepository;

        // public CountryController(ICountryRepository countryRepository)
        // {
        //     _countryRepository = countryRepository;
        // }

        [HttpGet("getcountries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("getcountry/{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country is null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost("createcountry")]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                var createdCountry = await _countryRepository.CreateCountryAsync(country);
                return CreatedAtAction(nameof(GetCountry), new { id = createdCountry.Id }, createdCountry);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updatecountry/{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country country)
        {
            try
            {
                var updatedCountry = await _countryRepository.UpdateCountryAsync(id, country);
                return Ok(updatedCountry);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("deletecountry/{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                await _countryRepository.DeleteCountryAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}