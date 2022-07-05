using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using Domain.Entities;

using MediatR;

namespace Application.Commands.Newss
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public NewsDTO NewsDTO { get; set; }
    }
}
