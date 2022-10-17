using GameZone.Application.Dtos;
using GameZone.Application.Filters;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesChart
{
    public class GetGamesChartQueryHandler : IRequestHandler<GetGamesChartQuery, GameDataDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGamesChartQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<GameDataDto> Handle(GetGamesChartQuery request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.GenreRepository.ReturnAllAsync();
            var platforms = await _unitOfWork.PlatformRepository.ReturnAllAsync();
            var data = new GameDataDto { GenreAverage = new List<GenreDataDto>(), PlatformCount = new List<PlatformDataDto>(), GenreCount = new List<GenreDataDto>() };

            foreach(var genre in genres)
            {
                var genreFilter = new GameFilter { Genre = genre.Name };
                var count = await _unitOfWork.GameRepository.CountAsync(genreFilter);
                var games = await _unitOfWork.GameRepository.ReturnFiltered(genreFilter);
                
                if (count != 0)
                {
                    var genreCount = new GenreDataDto { Count = count, Name = genre.Name };
                    data.GenreCount.Add(genreCount);

                    var averageRating = Math.Round(games.Average(x => x.TotalRating), 1);

                    if (averageRating > 0)
                    {
                        var genredata = new GenreDataDto
                        {
                            Count = count,
                            Name = genre.Name,
                            AverageRating = averageRating
                        };
                        data.GenreAverage.Add(genredata);
                    }
                }
            }

            foreach (var platform in platforms)
            {
                var platformFilter = new GameFilter { Platform = platform.Name };
                var count = await _unitOfWork.GameRepository.CountAsync(platformFilter);

                if (count != 0)
                {
                    var platformCount = new PlatformDataDto { Count = count, Name = platform.Name };
                    data.PlatformCount.Add(platformCount);

                }
            }
            return data;
        }
    }
}
