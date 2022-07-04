using Application.Interfaces;

using MediatR;

namespace Application.Commands
{
    public class DeleteNewsCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
