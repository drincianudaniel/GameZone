using MediatR;

namespace GameZone.Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
