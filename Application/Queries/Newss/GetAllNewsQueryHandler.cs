using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Newss
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsQueryResult>>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<NewsQueryResult>> Handle(GetAllNewsQuery query, CancellationToken token)
        {
            var news = await _context.NewsL.ToListAsync();

            return _mapper.Map<IEnumerable<NewsQueryResult>>(news);
        }
    }
}
