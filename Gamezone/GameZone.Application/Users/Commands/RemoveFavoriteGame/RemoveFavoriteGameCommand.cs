using MediatR;


namespace GameZone.Application.Users.Commands.RemoveFavoriteGame
{
    public class RemoveFavoriteGameCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
    }
}
