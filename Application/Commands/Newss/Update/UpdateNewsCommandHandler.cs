using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Exceptions;
using Application.Interfaces;

using MediatR;

namespace Application.Commands.Newss.Update
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Guid>
    {
        private readonly INewsContext _context;

        public UpdateNewsCommandHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateNewsCommand command, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(command.Id);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            news.Title = command.Title;

            news.Description = command.Description;

            news.UpdatedAt = DateTime.UtcNow;

            _context.NewsL.Update(news);

            await _context.SaveChangesAsync();

            return news.Id;
        }
    }
}
