namespace HotelListing.Api.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public virtual IList<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
