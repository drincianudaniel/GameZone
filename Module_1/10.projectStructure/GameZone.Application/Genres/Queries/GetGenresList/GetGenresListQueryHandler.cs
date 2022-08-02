using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, IEnumerable<GenresListVm>>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenresListQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<IEnumerable<GenresListVm>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var result = _genreRepository.ReturnAll().Select(genre => new GenresListVm
            {
                Id = genre.Id,
                GenreName = genre.Name
            });

            return Task.FromResult(result);
        }
    }
}
