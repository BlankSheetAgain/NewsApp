using Application.DTOs;

using MediatR;

namespace Application.Queries.Comments
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<CommentDTO>>
    {
        public Guid NewsId { get; set; }
    }
}
