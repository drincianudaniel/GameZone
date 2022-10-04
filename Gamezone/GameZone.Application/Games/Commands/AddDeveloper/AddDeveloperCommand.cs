using MediatR;


namespace GameZone.Application.Games.Commands.AddDeveloper
{
    public class AddDeveloperCommand : IRequest<bool>
    {
        public Guid GameId { get; set; }
        public Guid DeveloperId { get; set; }
    }
}
