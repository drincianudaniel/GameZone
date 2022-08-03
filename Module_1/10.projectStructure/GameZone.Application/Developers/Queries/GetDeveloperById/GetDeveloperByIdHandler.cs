using AutoMapper;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdHandler : IRequestHandler<GetDeveloperByIdQuery, DeveloperDto>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public GetDeveloperByIdHandler(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }
        public Task<DeveloperDto> Handle(GetDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var result = _developerRepository.ReturnById(id);
            var developerDto = _mapper.Map<DeveloperDto>(result);
            return Task.FromResult(developerDto);
        }
    }
}
