using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class UserDTO
    {

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public User ToUser()
        {
            return new User
            {
                Username = Username,
                Password = Password,
                Email = Email,
                Phone = Phone
            };
        }

        public static UserDTO FromUser(User user)
        {
            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}
