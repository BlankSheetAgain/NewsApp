using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Exceptions;
using Application.Interfaces;

using MediatR;

namespace Application.Commands.Comments.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Guid>
    {
        private readonly INewsContext _context;

        public UpdateCommentCommandHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateCommentCommand command, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(command.NewsId);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            var comment = _context.Comments.FirstOrDefault(c => c.Id == command.Id && c.News == news);

            if (comment == null) throw new ItemNotFoundException("Comment with this id does not exist");

            comment.Content = command.Content;

            comment.UpdatedAt = DateTime.UtcNow;

            _context.Comments.Update(comment);

            await _context.SaveChangesAsync();

            return comment.Id;

        }
    }
}
