using MediatR;

namespace GameZone.Application.Users.Commands.AddRoleToUser
{
    public class AddRoleToUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
