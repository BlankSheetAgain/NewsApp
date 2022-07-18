using Application.Interfaces;

using AutoMapper;

using MediatR;

namespace Application.Queries.Newss
{
    public class GetNewsByIdQuery : IRequest<NewsQueryResult>
    {
        public Guid Id { get; set; }
    }
}
