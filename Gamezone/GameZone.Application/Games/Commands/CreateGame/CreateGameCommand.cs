﻿using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public List<Guid> DeveloperList { get; set; } = new List<Guid>();
        public List<Guid> GenreList { get; set; } = new List<Guid>();
        public List<Guid> PlatformList { get; set; } = new List<Guid>();
    }
}
