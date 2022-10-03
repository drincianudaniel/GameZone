using MediatR;

namespace GameZone.Application.Users.Commands.RemoveRoleFromUser
{
    public class RemoveRoleFromUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
