using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest<Game>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string ImageSrc { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public List<Guid> DeveloperList { get; set; } = new List<Guid>();
        public List<Guid> GenreList { get; set; } = new List<Guid>();
        public List<Guid> PlatformList { get; set; } = new List<Guid>();
    }
}
