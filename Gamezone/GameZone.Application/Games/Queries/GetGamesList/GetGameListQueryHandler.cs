using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQueryHandler : IRequestHandler<GetGameListQuery, IEnumerable<GameDto>>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameListQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<IEnumerable<GameDto>> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            var result = _gameRepository.ReturnAll().Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                ReleaseDate = game.ReleaseDate,
                GameDetails = game.GameDetails,
                Developers = game.Developers,
                Genres = game.Genres,
                Platforms = game.Platforms,
                Comments = game.Comments
            });

            return Task.FromResult(result);
        }        
    }
}
