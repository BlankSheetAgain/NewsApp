using MediatR;

namespace Application.Commands
{
    public class DeleteCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
