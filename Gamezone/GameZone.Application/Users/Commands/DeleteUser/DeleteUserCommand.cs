using MediatR;

namespace GameZone.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
