using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformById
{
    internal class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, PlatformDto>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public GetPlatformByIdQueryHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }
        public async Task<PlatformDto> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _platformRepository.ReturnByIdAsync(id);
            var platformDto = _mapper.Map<PlatformDto>(result);
            return platformDto;
        }
    }
}
