using MediatR;


namespace GameZone.Application.Games.Commands.RemoveDeveloper
{
    public class RemoveDeveloperCommand : IRequest<bool>
    {
        public Guid GameId { get; set; }
        public Guid DeveloperId { get; set; }
    }
}
