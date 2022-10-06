using GameZone.Application.Dtos;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<GameWithUserFavoriteDTO>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

    }
}
