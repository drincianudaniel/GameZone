using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<GenreDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreToUpdate = new Genre();
            genreToUpdate.Id = request.Id;
            genreToUpdate.Name = request.Name;

            await _unitOfWork.GenreRepository.UpdateAsync(genreToUpdate);
            await _unitOfWork.SaveAsync();

            var genreDto = _mapper.Map<GenreDto>(genreToUpdate);
            return genreDto;
        }
    }
}
