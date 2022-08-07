using MediatR;

namespace GameZone.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
