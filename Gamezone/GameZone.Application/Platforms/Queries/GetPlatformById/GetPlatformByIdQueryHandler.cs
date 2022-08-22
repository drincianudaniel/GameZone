using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, PlatformDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlatformByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PlatformDto> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.PlatformRepository.ReturnByIdAsync(id);
            var platformDto = _mapper.Map<PlatformDto>(result);
            return platformDto;
        }
    }
}
