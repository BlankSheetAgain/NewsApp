using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Newss.Create
{
    public class CreateNewsCommandHendler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public CreateNewsCommandHendler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateNewsCommand command, CancellationToken token)
        {
            var news = new News
            {
                Title = command.Title,
                Description = command.Description
            };

            await _context.NewsL.AddAsync(news);

            await _context.SaveChangesAsync();

            return news.Id;
        }
    }
}
