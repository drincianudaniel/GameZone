using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, IEnumerable<DeveloperDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDevelopersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<DeveloperDto>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.DeveloperRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<DeveloperDto>>(query);
            return mappedResult;
        }
    }
}
