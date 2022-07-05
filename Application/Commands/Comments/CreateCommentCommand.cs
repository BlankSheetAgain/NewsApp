using Application.DTOs;

using MediatR;

namespace Application.Commands.Comments
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public CommentDTO CommentDTO { get; set; }
    }
}
