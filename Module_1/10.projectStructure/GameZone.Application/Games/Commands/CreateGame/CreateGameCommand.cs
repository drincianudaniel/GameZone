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
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; }
    }
}
