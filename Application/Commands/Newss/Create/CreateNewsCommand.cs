using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Newss.Create
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
