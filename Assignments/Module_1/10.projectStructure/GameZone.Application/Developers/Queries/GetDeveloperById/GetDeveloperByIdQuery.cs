using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQuery : IRequest<DeveloperDto>
    {
        public int Id { get; set; }
    }
}
