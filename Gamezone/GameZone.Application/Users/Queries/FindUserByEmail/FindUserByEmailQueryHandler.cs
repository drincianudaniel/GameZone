using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Queries.FindUserByEmail
{
    internal class FindUserByEmailQueryHandler : IRequestHandler<FindUserByEmailQuery, User>
    {
        private readonly UserManager<User> _userManager;

        public FindUserByEmailQueryHandler(UserManager<User> userManager)
        {
            _userManager=userManager;
        }

        public async Task<User> Handle(FindUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            return user;
        }
    
    }
}
