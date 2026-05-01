using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;
using HotelListing.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        
        [HttpGet("gethotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("gethotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost("createhotel")]
        public async Task<ActionResult<Hotel>> CreateHotel(Hotel hotel)
        {
            try
            {
                var createdHotel = await _hotelRepository.CreateHotelAsync(hotel);
                return CreatedAtAction(nameof(GetHotel), new { id = createdHotel.Id }, createdHotel);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletehotel/{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelRepository.DeleteHotelAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("updatehotel/{id}")]
        public async Task<ActionResult<Hotel>> UpdateHotel(int id, Hotel hotel)
        {
            try
            {
                var updatedHotel = await _hotelRepository.UpdateHotelAsync(id, hotel);
                return Ok(updatedHotel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}