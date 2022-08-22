using GameZone.Domain.Models;

namespace GameZone.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<GameDto> Games { get; set; } = new List<GameDto>();
        public string Role { get; set; } = string.Empty;
    }
}
