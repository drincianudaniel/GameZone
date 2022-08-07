using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommand : IRequest<Guid>
    {
        public Guid IdUser { get; set; }
        public Guid IdGame { get; set; }
    }
}
