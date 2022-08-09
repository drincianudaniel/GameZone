using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetReplyById
{
    public class GetReplyByIdQuery : IRequest<ReplyDto>
    {
        public Guid Id { get; set; }
    }
}
