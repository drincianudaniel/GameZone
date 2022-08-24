using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<Developer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeadQuarters { get; set; } = string.Empty;
    }
}
