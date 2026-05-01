using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private static List<Hotel> _hotels = new List<Hotel>
        {
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel 1",
                    Address = "Address 1",
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel 2",
                    Address = "Address 2",
                    Rating = 3.8
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel 3",
                    Address = "Address 3",
                    Rating = 4.2
                }
            };
        public HotelController()
        {
            
        }
        
        [HttpGet("gethotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            // var hotels = _hotels.ToList();
            return await Task.FromResult(Ok(_hotels));
        }

        [HttpGet("gethotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel is null)
            {
                return NotFound();
            }
            return await Task.FromResult(Ok(hotel));
        }

        [HttpPost("createhotel")]
        public async Task<ActionResult<Hotel>> CreateHotel(Hotel hotel)
        {
            if (_hotels.Any(h => h.Id == hotel.Id))
            {
                return BadRequest("Hotel with the same Id already exists.");
            }

            _hotels.Add(hotel);
            _hotels = _hotels.OrderBy(h => h.Id).ToList(); // Ensure the list is ordered by Id  
            return await Task.FromResult(CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel));
        }

        [HttpDelete("deletehotel/{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel is null)
            {
                return NotFound();
            }
            // _hotels = _hotels.Where(h => h.Id != id);
            _hotels.Remove(hotel);
            return await Task.FromResult(NoContent());
        }

        [HttpPut("updatehotel/{id}")]
        public async Task<ActionResult<Hotel>> UpdateHotel(int id, Hotel hotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel is null)
            {
                return NotFound();
            }
            // _hotels = _hotels.Where(h => h.Id != id).Append(hotel);
            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.Rating = hotel.Rating;

            return await Task.FromResult(Ok(existingHotel));
        }
    }
}