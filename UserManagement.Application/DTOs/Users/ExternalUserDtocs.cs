namespace UserManagement.Application.DTOs.Users
{
    public class ExternalUserDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public decimal GeoLat { get; set; }
        public decimal GeoLng { get; set; }
        public string? Website { get; set; }
    } 
}
