using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Comments
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
            var comment = _mapper.Map<News>(command.CommentDTO);

            await _context.NewsL.AddAsync(comment);

            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}
