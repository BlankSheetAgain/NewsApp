using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries.Newss
{
    public class GetNewsByIdQuery : IRequest<NewsDTO>
    {
        public Guid Id { get; set; }
    }
}
