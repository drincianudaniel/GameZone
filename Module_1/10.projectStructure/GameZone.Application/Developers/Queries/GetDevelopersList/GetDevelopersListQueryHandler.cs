using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandler : IRequestHandler<GetDevelopersListQuery, IEnumerable<DevelopersListVm>>
    {
        private readonly IDeveloperRepository _developerRepository;

        public GetDevelopersListQueryHandler(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Task<IEnumerable<DevelopersListVm>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var result = _developerRepository.ReturnAll().Select(developer => new DevelopersListVm
            {
                Id = developer.Id,
                DeveloperName = developer.Name,
                Headquarters = developer.Headquarters
            });

            return Task.FromResult(result);
        }
    }
}
