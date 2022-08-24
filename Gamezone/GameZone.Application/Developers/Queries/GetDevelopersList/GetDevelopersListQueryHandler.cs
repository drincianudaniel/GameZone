using AutoMapper;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, IEnumerable<Developer>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDevelopersListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Developer>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.DeveloperRepository.ReturnAllAsync();

            return query;
        }
    }
}
