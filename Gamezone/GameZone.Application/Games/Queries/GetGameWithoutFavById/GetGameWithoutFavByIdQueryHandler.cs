using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGameWithoutFavById
{
    public class GetGameWithoutFavByIdQueryHandler : IRequestHandler<GetGameWithoutFavByIdQuery, Game>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameWithoutFavByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Game> Handle(GetGameWithoutFavByIdQuery request, CancellationToken cancellationToken)
        {
            var game = _unitOfWork.GameRepository.ReturnByIdAsync(request.Id);
            return game;
        }
    }
}
