using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Queries.GetUserReviews
{
    public class GetUserReviewsQueryHandler : IRequestHandler<GetUserReviewsQuery, IEnumerable<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserReviewsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Review>> Handle(GetUserReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.UserRepository.GetUserReviews(request.UserName);
            return reviews;
        }
    }
}
