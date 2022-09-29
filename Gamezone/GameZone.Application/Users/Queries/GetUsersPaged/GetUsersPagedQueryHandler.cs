using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Users.Queries.GetUsersPaged
{
    public class GetUsersPagedQueryHandler : IRequestHandler<GetUsersPagedQuery, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.UserRepository.ReturnPagedAsync(request.Page, request.PageSize, request.SearchString);
            return query;
        }
    }
}
