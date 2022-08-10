using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, IEnumerable<PlatformDto>>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public GetPlatformsListQueryHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<PlatformDto>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _platformRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<PlatformDto>>(query);

            return mappedResult;
        }
    }
}
