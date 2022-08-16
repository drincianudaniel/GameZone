using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, DeveloperDto>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;

        public UpdateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper=mapper;
        }
        public async Task<DeveloperDto> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerToUpdate = new Developer();
            developerToUpdate.Id = request.Id;
            developerToUpdate.Name = request.Name;
            developerToUpdate.Headquarters = request.HeadQuarters;
            await _developerRepository.UpdateAsync(developerToUpdate);
            var developerDto = _mapper.Map<DeveloperDto>(developerToUpdate);
            return developerDto;
        }
    }
}
