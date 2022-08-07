using MediatR;

namespace GameZone.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
