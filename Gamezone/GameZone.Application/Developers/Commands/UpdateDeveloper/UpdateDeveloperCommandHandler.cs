using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, Developer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeveloperCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Developer> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developerToUpdate = new Developer();
            developerToUpdate.Id = request.Id;
            developerToUpdate.Name = request.Name;
            developerToUpdate.Headquarters = request.HeadQuarters;

            await _unitOfWork.DeveloperRepository.UpdateAsync(developerToUpdate);
            await _unitOfWork.SaveAsync();

            return developerToUpdate;
        }
    }
}
