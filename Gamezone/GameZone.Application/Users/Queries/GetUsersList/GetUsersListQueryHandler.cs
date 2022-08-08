using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<IEnumerable<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var result = _userRepository.ReturnAll().Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Games = user.Games,

            });

            return Task.FromResult(result);
        }
    }
}
