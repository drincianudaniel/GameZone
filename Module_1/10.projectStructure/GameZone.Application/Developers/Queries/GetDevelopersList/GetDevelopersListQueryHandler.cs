using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, IEnumerable<DeveloperDto>>
    {
        private readonly IDeveloperRepository _developerRepository;

        public GetDevelopersListQueryHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Task<IEnumerable<DeveloperDto>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var result = _developerRepository.ReturnAll().Select(developer => new DeveloperDto
            {
                Id = developer.Id,
                Name = developer.Name,
                Headquarters = developer.Headquarters
            });

            return Task.FromResult(result);
        }
    }
}
