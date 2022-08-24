using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<Genre>
    {
        public Guid Id { get; set; }
    }
}
