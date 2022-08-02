using GameZoneModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<GameDto>
    {
        public int Id { get; set; }
    }
}
