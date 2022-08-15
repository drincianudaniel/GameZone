using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, DeveloperDto>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper=mapper;
        }
        public async Task<DeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer { Name = request.Name, Headquarters = request.HeadQuarters };
            await _developerRepository.CreateAsync(developer);

            var developerDto = _mapper.Map<DeveloperDto>(developer);
            return developerDto;
        }
    }
}
