using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries
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

        public async Task<IEnumerable<CommentDTO>> Handle (GetAllCommentsQuery query, CancellationToken token)
        {
            var comments = _context.Comments.ToList();

            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
    }
}
