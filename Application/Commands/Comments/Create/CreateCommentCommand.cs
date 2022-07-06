using Application.DTOs;

using MediatR;

namespace Application.Commands.Comments.Create
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public CommentDTO CommentDTO { get; set; }
    }
}
