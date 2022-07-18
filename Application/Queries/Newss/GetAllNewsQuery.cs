using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Newss
{
    public class GetAllNewsQuery : IRequest<IEnumerable<NewsQueryResult>>
    {

    }
}
