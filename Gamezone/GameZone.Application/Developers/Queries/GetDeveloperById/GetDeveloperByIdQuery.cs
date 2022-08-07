using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQuery : IRequest<DeveloperDto>
    {
        public Guid Id { get; set; }
    }
}
