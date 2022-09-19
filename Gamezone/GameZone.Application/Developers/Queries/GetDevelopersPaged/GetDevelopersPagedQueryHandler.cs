using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersPaged
{
    public class GetDevelopersPagedQueryHandler : IRequestHandler<GetDevelopersPagedQuery, IEnumerable<Developer>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDevelopersPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Developer>> Handle(GetDevelopersPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.DeveloperRepository.ReturnPagedAsync(request.Page, request.PageSize);
            return query;
        }
    }
}
