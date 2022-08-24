using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQueryHandler : IRequestHandler<GetDeveloperByIdQuery, Developer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDeveloperByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Developer> Handle(GetDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.DeveloperRepository.ReturnByIdAsync(id);

            return result;
        }
    }
}
