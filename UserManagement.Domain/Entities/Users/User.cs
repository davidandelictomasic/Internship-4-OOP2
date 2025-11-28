using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Abstractions;

namespace UserManagement.Domain.Entities.Users
{
    public class User : Entity
    {
       
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string AddressStreet { get; private set; }
        public string AddressCity { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
        public string? Website { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; } = true;

        public const int NameMaxLength = 100;
        public const int AddressStreetMaxLength = 150;
        public const int AddressCityMaxLength = 100;
        public const int WebsiteMaxLength = 100;

        public async Task Create()
        {
            

        }
        public async Task CreateOrUpdateValidation()
        {
            
        }
    }
}
