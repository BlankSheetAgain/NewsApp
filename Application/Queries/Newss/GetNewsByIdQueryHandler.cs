using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries.Newss
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
            var news = _context.NewsL.FirstOrDefault(n => n.Id == query.Id);

            if (news == null) throw new ItemNotFoundException("The specified news item was not found");

            return _mapper.Map<NewsDTO>(news);
        }
    }
}
