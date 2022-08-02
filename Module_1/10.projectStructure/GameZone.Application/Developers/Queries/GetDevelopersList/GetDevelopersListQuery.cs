using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Developers.Queries.GetDevelopersList
{
    public class GetDevelopersListQuery : IRequest<IEnumerable<DeveloperListVm>>
    {

    }
}
