using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, IEnumerable<PlatformDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPlatformsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<PlatformDto>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.PlatformRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<PlatformDto>>(query);

            return mappedResult;
        }
    }
}
