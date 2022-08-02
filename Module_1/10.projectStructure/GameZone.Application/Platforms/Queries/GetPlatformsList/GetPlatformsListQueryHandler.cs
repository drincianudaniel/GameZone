using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQueryHandler : IRequestHandler<GetPlatformsListQuery, IEnumerable<PlatformsListVm>>
    {
        private readonly IPlatformRepository _platformRepository;

        public GetPlatformsListQueryHandler(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public Task<IEnumerable<PlatformsListVm>> Handle(GetPlatformsListQuery request, CancellationToken cancellationToken)
        {
            var result = _platformRepository.ReturnAll().Select(platform => new PlatformsListVm
            {
                Id = platform.Id,
                PlatformName = platform.Name
            });

            return Task.FromResult(result);
        }
    }
}
