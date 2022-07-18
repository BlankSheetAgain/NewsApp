using MediatR;

namespace Application.Commands.Comments.Create
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public string Content { get; set; }

        public Guid NewsId { get; set; }
    }
}
