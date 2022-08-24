using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.UserRepository.ReturnByIdAsync(id);
            return result;
        }
    }
}
