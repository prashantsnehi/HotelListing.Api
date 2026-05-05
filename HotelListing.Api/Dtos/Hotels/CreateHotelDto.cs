namespace HotelListing.Api.Dtos.Hotels;

public record CreateHotelDto(
    string Name,
    string Address,
    double Rating,
    int CountryId
);
