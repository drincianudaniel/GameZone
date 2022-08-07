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
        public Task<PlatformDto> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = _platformRepository.ReturnById(id);
            var platformDto = _mapper.Map<PlatformDto>(result);
            return Task.FromResult(platformDto);
        }
    }
}
