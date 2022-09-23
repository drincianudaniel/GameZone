using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
