using MediatR;

namespace GameZone.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
