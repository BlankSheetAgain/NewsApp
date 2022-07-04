using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Queries
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, NewsDTO>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetNewsByIdQueryHandler(IMapper mapper, INewsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<NewsDTO> Handle(GetNewsByIdQuery query, CancellationToken token)
        {
            var news = _context.NewsL.FirstOrDefault(n => n.Id == null);

            return _mapper.Map<NewsDTO>(news);
        }
    }
}
