using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Newss
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
            var news = _mapper.Map<News>(command.NewsDTO);

            await _context.NewsL.AddAsync(news);

            await _context.SaveChangesAsync();

            return news.Id;
        }
    }
}
