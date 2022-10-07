using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGameWithoutFavById
{
    public class GetGameWithoutFavByIdQuery : IRequest<Game>
    {
        public Guid Id { get; set; }

    }
}
