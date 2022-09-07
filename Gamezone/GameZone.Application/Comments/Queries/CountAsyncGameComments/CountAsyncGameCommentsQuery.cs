using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Comments.Queries.CountAsyncGameComments
{
    public class CountAsyncGameCommentsQuery : IRequest<int>
    {
        public Guid GameId { get; set; }
    }
}
