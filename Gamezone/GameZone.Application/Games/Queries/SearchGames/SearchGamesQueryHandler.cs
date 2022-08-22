using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Queries.SearchGames
{
    public class SearchGamesQueryHandler : IRequestHandler<SearchGamesQuery, IEnumerable<SimpleGameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchGamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<SimpleGameDto>> Handle(SearchGamesQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.SearchGameAsync(request.searchString);
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(query);
            return mappedResult;
        }
    }
}
