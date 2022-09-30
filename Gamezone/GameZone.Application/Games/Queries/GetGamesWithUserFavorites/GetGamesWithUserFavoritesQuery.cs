using GameZone.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGamesWithUserFavorites
{
    public class GetGamesWithUserFavoritesQuery : IRequest<IEnumerable<GamesWithUserFavoritesDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string UserName { get; set; }
    }
}
