using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, PlatformDto>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public CreatePlatformCommandHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper=mapper;
        }
        public async Task<PlatformDto> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform { Name = request.Name };
            await _platformRepository.CreateAsync(platform);
            var platformDto = _mapper.Map<PlatformDto>(platform);

            return platformDto;
        }
    }
}
