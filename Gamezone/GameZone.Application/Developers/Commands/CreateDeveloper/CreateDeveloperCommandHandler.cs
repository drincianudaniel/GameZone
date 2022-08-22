using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, DeveloperDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateDeveloperCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<DeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer { Name = request.Name, Headquarters = request.HeadQuarters };

            await _unitOfWork.DeveloperRepository.CreateAsync(developer);
            await _unitOfWork.SaveAsync();

            var developerDto = _mapper.Map<DeveloperDto>(developer);
            return developerDto;
        }
    }
}
