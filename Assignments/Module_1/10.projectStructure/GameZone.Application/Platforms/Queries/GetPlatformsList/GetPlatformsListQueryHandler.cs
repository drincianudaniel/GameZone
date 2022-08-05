using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, IEnumerable<PlatformDto>>
    {
        private readonly IPlatformRepository _platformRepository;

        public GetPlatformsListQueryHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public Task<IEnumerable<PlatformDto>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var result = _platformRepository.ReturnAll().Select(platform => new PlatformDto
            {
                Id = platform.Id,
                Name = platform.Name
            });

            return Task.FromResult(result);
        }
    }
}
