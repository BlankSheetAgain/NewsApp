using Application.Interfaces;
using MediatR;

namespace Application.Commands
{
    public class DeleteNewsCommandQueryHandler : IRequestHandler<DeleteNewsCommand, Guid>
    {
        private readonly INewsContext _context;

        public DeleteNewsCommandQueryHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteNewsCommand command, CancellationToken token)
        {
            var news = _context.NewsL.FirstOrDefault(n => n.Id == command.Id);

            _context.NewsL.Remove(news);

            await _context.SaveChangesAsync();

            return news.Id;
        }
    }
}
