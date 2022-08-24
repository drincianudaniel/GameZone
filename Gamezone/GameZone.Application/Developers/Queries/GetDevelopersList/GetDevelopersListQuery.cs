using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQuery : IRequest<IEnumerable<Developer>>
    {
    }
}
