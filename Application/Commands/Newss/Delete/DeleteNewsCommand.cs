using Application.Interfaces;

using MediatR;

namespace Application.Commands.Newss.Delete
{
    public class DeleteNewsCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
