using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGamesPaged
{
    public class GetGamesPagedQueryHandler : IRequestHandler<GetGamesPagedQuery, IEnumerable<GameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGamesPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameDto>> Handle(GetGamesPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.ReturnPagedAsync(request.Page);
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(query);
            return mappedResult;
        }
    }
}
