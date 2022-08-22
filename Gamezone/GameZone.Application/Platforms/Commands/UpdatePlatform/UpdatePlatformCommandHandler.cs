using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, PlatformDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<PlatformDto> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var platformToUpdate = new Platform();
            platformToUpdate.Id = request.Id;
            platformToUpdate.Name = request.Name;

            await _unitOfWork.PlatformRepository.UpdateAsync(platformToUpdate);
            await _unitOfWork.SaveAsync();

            var platformDto = _mapper.Map<PlatformDto>(platformToUpdate);
            return platformDto;
        }
    }
}
