using MediatR;

namespace GameZone.Application.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
