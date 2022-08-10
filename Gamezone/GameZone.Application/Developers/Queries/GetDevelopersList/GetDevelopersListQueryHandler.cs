using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, IEnumerable<DeveloperDto>>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;

        public GetDevelopersListQueryHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<DeveloperDto>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var query = await _developerRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<DeveloperDto>>(query);
            return mappedResult;
        }
    }
}
