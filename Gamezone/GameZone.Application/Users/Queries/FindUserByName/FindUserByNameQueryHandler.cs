using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Users.Queries.FindUserByName
{
    public class FindUserByNameQueryHandler : IRequestHandler<FindUserByNameQuery, User>
    {
        private readonly UserManager<User> _userManager;

        public FindUserByNameQueryHandler(UserManager<User> userManager)
        {
            _userManager=userManager;
        }

        public async Task<User> Handle(FindUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            return user;
        }
    }
}
