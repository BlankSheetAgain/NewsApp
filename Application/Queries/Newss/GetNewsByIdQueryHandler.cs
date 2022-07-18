using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries.Newss
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, NewsQueryResult>
    {
        private readonly INewsContext _context;

        public GetNewsByIdQueryHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<NewsQueryResult> Handle(GetNewsByIdQuery query, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(query.Id);

            if (news == null) throw new ItemNotFoundException("The specified news item was not found");

            var newsResult = new NewsQueryResult
            {
                Id = news.Id,

                Title = news.Title,

                Description = news.Description,

                CreatedAt = news.CreatedAt,

                UpdatedAt = news.UpdatedAt
            };

            return newsResult;
        }
    }
}
