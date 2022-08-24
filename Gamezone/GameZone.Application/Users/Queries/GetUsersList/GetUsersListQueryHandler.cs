using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.UserRepository.ReturnAllAsync();
            return query;
        }
    }
}
