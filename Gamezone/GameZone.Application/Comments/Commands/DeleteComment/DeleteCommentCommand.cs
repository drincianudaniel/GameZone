using MediatR;

namespace GameZone.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
