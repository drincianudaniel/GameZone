using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<Game>
    {
        public Guid Id { get; set; }
    }
}
