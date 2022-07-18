using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries.Comments
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentQueryResult>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<CommentQueryResult> Handle(GetCommentByIdQuery query, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(query.NewsId);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            var comment = _context.Comments.FirstOrDefault(c => c.Id == query.Id && c.News == news);

            if (comment == null) throw new ItemNotFoundException("Comment with this id does not exist");

            var commentResult = new CommentQueryResult
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };

            return commentResult;
        }
    }
}
