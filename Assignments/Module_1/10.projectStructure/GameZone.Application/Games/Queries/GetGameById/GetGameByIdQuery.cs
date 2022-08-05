using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<GameDto>
    {
        public int Id { get; set; }
    }
}
