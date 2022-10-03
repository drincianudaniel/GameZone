using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Commands.AddGenre
{
    public class AddGenreCommand : IRequest<bool>
    {
        public Guid GameId { get; set; }
        public Guid GenreId { get; set; }
    }
}
