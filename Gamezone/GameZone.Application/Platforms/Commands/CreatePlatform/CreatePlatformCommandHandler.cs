using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, PlatformDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreatePlatformCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<PlatformDto> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platform = new Platform { Name = request.Name };

            await _unitOfWork.PlatformRepository.CreateAsync(platform);
            await _unitOfWork.SaveAsync();

            var platformDto = _mapper.Map<PlatformDto>(platform);

            return platformDto;
        }
    }
}
