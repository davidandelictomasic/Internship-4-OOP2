using UserManagement.Domain.Entities.Users;

namespace UserManagement.Application.DTOs.Users
{
    public class UserDto
    {
        
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static UserDto FromEntity(User u)
        {
            return new UserDto
            {
               
                Name = u.Name,
                Username = u.Username,
                Email = u.Email
            };
        }
    }

}
