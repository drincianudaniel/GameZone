using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Users.Commands.AddRoleToUser
{
    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AddRoleToUserCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager=userManager;
            _roleManager=roleManager;
        }

        public async Task<bool> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            var role = await _roleManager.FindByNameAsync(request.RoleName);

            if (role == null)
            {
                var roleAdded = await _roleManager.CreateAsync(new Role()
                {
                    Name = request.RoleName
                });
            }

            var addRoleToUser = await _userManager.AddToRoleAsync(user, request.RoleName);

            return addRoleToUser.Succeeded;
        }
    }
}
