using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, IEnumerable<GenreDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenresListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GenreRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<GenreDto>>(query);

            return mappedResult;
        }
    }
}
