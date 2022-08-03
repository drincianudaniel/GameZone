using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQuery : IRequest<IEnumerable<DeveloperDto>>
    {
    }
}
