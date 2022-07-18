using Application.Exceptions;
using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Comments.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(INewsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCommentCommand command, CancellationToken token)
        {
            var news = await _context.NewsL.FindAsync(command.NewsId);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            var comment = new Comment
            {
                Content = command.Content,

                News = news
            };

            return comment.Id;
        }
    }
}
