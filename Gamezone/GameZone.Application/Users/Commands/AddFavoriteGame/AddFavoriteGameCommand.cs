using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public int IdGame { get; set; }
    }
}
