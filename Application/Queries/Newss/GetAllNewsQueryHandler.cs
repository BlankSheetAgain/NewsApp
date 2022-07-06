using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Newss
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsDTO>>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<NewsDTO>> Handle(GetAllNewsQuery query, CancellationToken token)
        {
            var news = await _context.NewsL.ToListAsync();

            if (news == null) throw new ItemNotFoundException("No news has been added yet");

            return _mapper.Map<IEnumerable<NewsDTO>>(news);
        }
    }
}
