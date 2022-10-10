namespace GameZone.Api.DTOs
{
    public class AutoCompleteGameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Games";
    }
}
