using Application.DTOs;

using MediatR;

namespace Application.Commands
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public CommentDTO CommentDTO { get; set; }
    }
}
