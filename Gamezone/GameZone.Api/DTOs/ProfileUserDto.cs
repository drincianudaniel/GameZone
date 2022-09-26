namespace GameZone.Api.DTOs
{
    public class ProfileUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImageSrc { get; set; }
        public ICollection<SimpleGameDto> Games { get; set; } = new List<SimpleGameDto>();
    }
}
