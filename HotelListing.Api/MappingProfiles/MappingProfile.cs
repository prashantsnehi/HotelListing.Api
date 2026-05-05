using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Api.Data;
using HotelListing.Api.Dtos.Hotels;

namespace HotelListing.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, GetHotelDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
        }
    }
}