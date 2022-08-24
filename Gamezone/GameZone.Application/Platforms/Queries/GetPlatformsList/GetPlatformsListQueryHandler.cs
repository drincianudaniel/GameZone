using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, IEnumerable<Platform>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPlatformsListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Platform>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.PlatformRepository.ReturnAllAsync();
            return query;
        }
    }
}
