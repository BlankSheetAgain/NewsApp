using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Comments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentDTO>>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> Handle(GetAllCommentsQuery query, CancellationToken token)
        {
            var comments = await _context.Comments.ToListAsync();

            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
    }
}
