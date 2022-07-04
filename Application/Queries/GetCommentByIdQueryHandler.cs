using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDTO>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentDTO> Handle(GetCommentByIdQuery query, CancellationToken token)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == query.Id);

            return _mapper.Map<CommentDTO>(comment);    
        }
    }
}
