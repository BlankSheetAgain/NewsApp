using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Queries.Comments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentQueryResult>>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentQueryResult>> Handle(GetAllCommentsQuery query, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(query.NewsId);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            var comments = await _context.Comments.Where(c => c.News == news).ToListAsync();

            return _mapper.Map<IEnumerable<CommentQueryResult>>(comments);
        }
    }
}
