using GameZone.Application.Dtos;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesChart
{
    public class GetGamesChartQuery : IRequest<GameDataDto>
    {
    }
}
