using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public LoginUserQueryHandler(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _configuration=configuration;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var isAdmin = new Claim("IsAdmin", true.ToString(), ClaimValueTypes.Boolean);
                var isAdminFalse = new Claim("IsAdmin", false.ToString(), ClaimValueTypes.Boolean);

                var authClaims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email),
                    new Claim("ProfileImage", user.ProfileImageSrc),
                    new Claim("IsLoggedIn", true.ToString(), ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    isAdminFalse
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                    if (userRole.Equals("Admin"))
                    {
                        authClaims.Remove(isAdminFalse);
                        authClaims.Add(isAdmin);
                    }
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtToken:Token").Value));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7092",
                    audience: "http://localhost:3000",
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
