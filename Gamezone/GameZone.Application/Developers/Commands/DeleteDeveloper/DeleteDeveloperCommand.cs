using MediatR;

namespace GameZone.Application.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
