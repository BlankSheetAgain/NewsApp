using Application.Interfaces;

using AutoMapper;

using Domain.Entities;
using Domain.Identity;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace Application.Commands.Newss.Create
{
    public class CreateNewsCommandHendler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly INewsContext _context;

        private readonly IMapper _mapper;

        private readonly ICurrentUserService _currentUserService;

        private readonly UserManager<ApplicationUser> _userManager;

        public CreateNewsCommandHendler(INewsContext context, IMapper mapper /*ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager*/)
        {
            _context = context;
            _mapper = mapper;
            //_currentUserService = currentUserService;
            //_userManager = userManager;
        }

        public async Task<Guid> Handle(CreateNewsCommand command, CancellationToken token)
        {
            //var user = await _userManager.FindByIdAsync(_currentUserService.Id);

            var news = new News
            {
                Title = command.Title,
                Description = command.Description,
                //User = user
            };

            await _context.NewsL.AddAsync(news);

            await _context.SaveChangesAsync();

            return news.Id;
        }
    }
}
