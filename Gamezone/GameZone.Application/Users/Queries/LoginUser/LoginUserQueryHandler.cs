using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameZone.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public LoginUserQueryHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager=userManager;
            _roleManager=roleManager;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email),
                    new Claim("ProfileImage", user.ProfileImageSrc),
                    new Claim("IsLoggedIn", true.ToString(), ClaimValueTypes.Boolean)
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim("Roles", userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4d97124e-3864-4ce6-9d5c-bfb06f2e22eb"));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7092",
                    audience: "https://localhost:3000",
                    claims: authClaims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return "Unauthorized";
        }
    }
}
