using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesTop
{
    public class GetGamesTopQueryHandler : IRequestHandler<GetGamesTopQuery, IEnumerable<SimpleGameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGamesTopQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SimpleGameDto>> Handle(GetGamesTopQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.GenerateTopList();
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(query);
            return mappedResult;
        }
    }
}
