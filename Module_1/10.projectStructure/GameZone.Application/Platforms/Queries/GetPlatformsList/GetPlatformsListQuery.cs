using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListQuery : IRequest<IEnumerable<PlatformsListVm>>
    {

    }
}
