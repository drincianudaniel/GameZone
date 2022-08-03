using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public ICollection<DeveloperDto> Developers { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<PlatformDto> Platforms { get; set; }

    }
}
