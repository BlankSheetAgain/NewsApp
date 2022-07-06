
using MediatR;

namespace Application.Commands.Comments.Delete
{
    public class DeleteCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public Guid NewsId { get; set; }
    }
}
