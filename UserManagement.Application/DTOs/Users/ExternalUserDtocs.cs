namespace UserManagement.Application.DTOs.Users
{
    public class ExternalUserDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string? Website { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class AddressDto
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoDto Geo { get; set; }
    }

    public class GeoDto
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}
