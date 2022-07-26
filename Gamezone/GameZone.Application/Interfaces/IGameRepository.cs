﻿using GameZone.Application.Filters;
using GameZone.Domain.Models;

namespace GameZone.Application
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task AddDeveloper(Game game, Developer developer);
        Task AddDeveloperListAsync(Game game, List<Developer> developers);
        Task AddGenreAsync(Game game, Genre genre);
        Task AddGenreListAsync(Game game, List<Genre> genres);
        Task AddPlatformAsync(Game game, Platform platform);
        Task AddPlatformListAsync(Game game, List<Platform> platforms);
        Task CalculateTotalRatingAsync(Game game);
        Task<int> CountAsync(GameFilter filter);
        Task<IEnumerable<Game>> GenerateTopList(int? page, int pageSize);
        Task<IEnumerable<Game>> GetNumberOfGames(int number, string sortOrder);
        Task RemoveDeveloperAsync(Game game, Developer developer);
        Task RemoveGenreAsync(Game game, Genre genre);
        Task RemovePlatformAsync(Game game, Platform platform);
        Task<IEnumerable<Game>> ReturnFiltered(GameFilter filter);
        Task<IEnumerable<Game>> ReturnPagedAsync(int? page, int pageSize, GameFilter filter);
        Task<Game> ReturnSimpleByIdAsync(Guid id);
        Task SaveAsync();
        Task<IEnumerable<Game>> SearchGameAsync(string searchString);
    }
}
