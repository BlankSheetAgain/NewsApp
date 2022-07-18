using MediatR;

namespace Application.Commands
{
    public class UpdateNewsCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
