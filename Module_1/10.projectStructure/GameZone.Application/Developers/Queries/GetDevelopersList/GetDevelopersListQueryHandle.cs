using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQueryHandle : IRequestHandler<GetDevelopersListQuery, IEnumerable<DeveloperListVm>>
    {
        private readonly IDeveloperRepository _developerRepository;

        public GetDevelopersListQueryHandle(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Task<IEnumerable<DeveloperListVm>> Handle(GetDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var result = _developerRepository.ReturnAll().Select(developer => new DeveloperListVm
            {
                Id = developer.Id,
                DeveloperName = developer.Name
            });

            return Task.FromResult(result);
        }
    }
}
