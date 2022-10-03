using GameZone.Application.Dtos;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Application.Users.Queries.GetUsersPaged
{
    public class GetUsersPagedQueryHandler : IRequestHandler<GetUsersPagedQuery, IEnumerable<UserWithRolesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public GetUsersPagedQueryHandler(IUnitOfWork unitOfWork, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _unitOfWork=unitOfWork;
            _roleManager=roleManager;
            _userManager=userManager;
        }

        public async Task<IEnumerable<UserWithRolesDto>> Handle(GetUsersPagedQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.ReturnPagedAsync(request.Page, request.PageSize, request.SearchString);
            var usersToReturn = new List<UserWithRolesDto>();
            foreach(var user in users)
            {
                var role = (await _userManager.GetRolesAsync(user)).ToList();
                var userWithRoles = new UserWithRolesDto
                {
                    User = user,
                    Roles = role
                };
                usersToReturn.Add(userWithRoles);
            }
            return usersToReturn;
        }
    }
}
