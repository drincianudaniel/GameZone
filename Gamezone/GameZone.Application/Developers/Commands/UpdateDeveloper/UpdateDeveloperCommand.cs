using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest<DeveloperDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeadQuarters { get; set; } = string.Empty;
    }
}
