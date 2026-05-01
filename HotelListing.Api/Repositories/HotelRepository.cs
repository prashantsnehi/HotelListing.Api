using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;

namespace HotelListing.Api.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private static List<Hotel> _hotels = new List<Hotel>
        {
            new Hotel
            {
                Id = 1,
                Name = "Redison Blu",
                Address = "Andheri West",
                Rating = 4.5
            },
            new Hotel
            {
                Id = 2,
                Name = "Crowne Plaza",
                Address = "Santa Cruz",
                Rating = 3.8
            },
            new Hotel
            {
                Id = 3,
                Name = "The Taj Mahal",
                Address = "Marina Bay",
                Rating = 4.2
            }
        };

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await Task.FromResult(_hotels);
        }

        public async Task<Hotel?> GetHotelByIdAsync(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            return await Task.FromResult(hotel);
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            if (_hotels.Any(h => h.Id == hotel.Id))
            {
                throw new InvalidOperationException("Hotel with the same Id already exists.");
            }

            _hotels.Add(hotel);
            _hotels = _hotels.OrderBy(h => h.Id).ToList();
            return await Task.FromResult(hotel);
        }

        public async Task<Hotel> UpdateHotelAsync(int id, Hotel hotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel is null)
            {
                throw new KeyNotFoundException($"Hotel with Id {id} not found.");
            }

            existingHotel.Name = hotel.Name;
            existingHotel.Address = hotel.Address;
            existingHotel.Rating = hotel.Rating;

            return await Task.FromResult(existingHotel);
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel is null)
            {
                throw new KeyNotFoundException($"Hotel with Id {id} not found.");
            }

            _hotels.Remove(hotel);
            return await Task.FromResult(true);
        }
    }
}
