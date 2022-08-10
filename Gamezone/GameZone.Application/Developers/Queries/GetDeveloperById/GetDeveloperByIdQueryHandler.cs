using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQueryHandler : IRequestHandler<GetDeveloperByIdQuery, DeveloperDto>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public GetDeveloperByIdQueryHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        public async Task<DeveloperDto> Handle(GetDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _developerRepository.ReturnByIdAsync(id);
            var developerDto = _mapper.Map<DeveloperDto>(result);
            return developerDto;
        }
    }
}
