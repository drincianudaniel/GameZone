using MediatR;

namespace GameZone.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
