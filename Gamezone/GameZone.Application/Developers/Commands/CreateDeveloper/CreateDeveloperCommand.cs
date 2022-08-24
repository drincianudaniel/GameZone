using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<Developer>
    {
        public string Name { get; set; } = string.Empty;
        public string HeadQuarters { get; set; } = string.Empty;
    }
}
