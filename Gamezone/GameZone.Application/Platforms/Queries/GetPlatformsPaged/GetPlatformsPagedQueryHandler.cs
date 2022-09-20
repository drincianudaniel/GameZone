using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Platforms.Queries.GetPlatformsPaged
{
    public class GetPlatformsPagedQueryHandler : IRequestHandler<GetPlatformsPagedQuery, IEnumerable<Platform>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlatformsPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Platform>> Handle(GetPlatformsPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.PlatformRepository.ReturnPagedAsync(request.Page, request.PageSize);
            return query;
        }
    }
}
