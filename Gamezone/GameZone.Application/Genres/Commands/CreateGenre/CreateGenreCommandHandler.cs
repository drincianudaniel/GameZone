using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Name };

            await _unitOfWork.GenreRepository.CreateAsync(genre);
            await _unitOfWork.SaveAsync();

            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }
    }
}
