using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, DeveloperDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDeveloperCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<DeveloperDto> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerToUpdate = new Developer();
            developerToUpdate.Id = request.Id;
            developerToUpdate.Name = request.Name;
            developerToUpdate.Headquarters = request.HeadQuarters;

            await _unitOfWork.DeveloperRepository.UpdateAsync(developerToUpdate);
            await _unitOfWork.SaveAsync();

            var developerDto = _mapper.Map<DeveloperDto>(developerToUpdate);
            return developerDto;
        }
    }
}
