using AutoMapper;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, Developer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeveloperCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Developer> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer { Name = request.Name, Headquarters = request.HeadQuarters };

            await _unitOfWork.DeveloperRepository.CreateAsync(developer);
            await _unitOfWork.SaveAsync();

            return developer;
        }
    }
}
