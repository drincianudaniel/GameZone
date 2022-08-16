using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, PlatformDto>
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper=mapper;
        }
        public async Task<PlatformDto> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platformToUpdate = new Platform();
            platformToUpdate.Id = request.Id;
            platformToUpdate.Name = request.Name;
            await _platformRepository.UpdateAsync(platformToUpdate);
            var platformDto = _mapper.Map<PlatformDto>(platformToUpdate);
            return platformDto;
        }
    }
}
