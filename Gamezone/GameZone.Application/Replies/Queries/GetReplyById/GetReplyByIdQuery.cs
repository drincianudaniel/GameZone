using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetReplyById
{
    public class GetReplyByIdQuery : IRequest<Reply>
    {
        public Guid Id { get; set; }
    }
}
