using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQuery : IRequest<Developer>
    {
        public Guid Id { get; set; }
    }
}
