using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Developers.Queries.GetDevelopersPaged
{
    public class GetDevelopersPagedQuery : IRequest<IEnumerable<Developer>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
