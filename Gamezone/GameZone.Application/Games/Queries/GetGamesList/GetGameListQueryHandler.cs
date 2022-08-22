using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQueryHandler : IRequestHandler<GetGameListQuery, IEnumerable<GameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetGameListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameDto>> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GameRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(query);
            return mappedResult;
        }        
    }
}
