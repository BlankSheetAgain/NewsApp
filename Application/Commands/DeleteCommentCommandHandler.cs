using Application.Interfaces;

using MediatR;

namespace Application.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Guid>
    {
        private readonly INewsContext _context;

        public DeleteCommentCommandHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCommentCommand command, CancellationToken token)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == command.Id);

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}