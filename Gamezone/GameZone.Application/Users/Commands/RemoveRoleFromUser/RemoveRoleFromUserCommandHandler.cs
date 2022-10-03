using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Users.Commands.RemoveRoleFromUser
{
    public class RemoveRoleFromUserCommandHandler : IRequestHandler<RemoveRoleFromUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RemoveRoleFromUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager=userManager;
            _roleManager=roleManager;
        }

        public async Task<bool> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            var removeRole = await _userManager.RemoveFromRoleAsync(user, request.RoleName);

            return removeRole.Succeeded;

        }
    }
}
