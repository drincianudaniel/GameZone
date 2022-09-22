using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager=userManager;
            _roleManager=roleManager;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var userExists = await _userManager.FindByNameAsync(request.UserName);

            /*if (userExists != null)
                return Unit.Equals(userExists, true);*/


            var user = new User { Email = request.Email, UserName = request.UserName, FirstName = request.FirstName, LastName = request.LastName, ProfileImageSrc = request.ProfileImageSrc};

            var result = await _userManager.CreateAsync(user, request.Password);

            /*await _unitOfWork.SaveAsync();*/

            return user;
        }
    }
}
