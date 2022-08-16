using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper=mapper;
        }
        public async Task<GenreDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreToUpdate = new Genre();
            genreToUpdate.Id = request.Id;
            genreToUpdate.Name = request.Name;

            await _genreRepository.UpdateAsync(genreToUpdate);
            var genreDto = _mapper.Map<GenreDto>(genreToUpdate);
            return genreDto;
        }
    }
}
