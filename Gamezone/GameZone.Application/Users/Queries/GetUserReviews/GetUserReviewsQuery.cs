using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Queries.GetUserReviews
{
    public class GetUserReviewsQuery : IRequest<IEnumerable<Review>>
    {
        public string UserName { get; set; }
    }
}
