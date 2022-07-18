using MediatR;

namespace Application.Queries.Comments
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<CommentQueryResult>>
    {
        public Guid NewsId { get; set; }
    }
}
