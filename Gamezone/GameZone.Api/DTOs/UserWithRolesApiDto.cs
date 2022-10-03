namespace GameZone.Api.DTOs
{
    public class UserWithRolesApiDto
    {
        public UserDto User { get; set; }
        public List<string> Roles { get; set; }
    }
}
