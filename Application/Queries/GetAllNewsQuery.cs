using Application.DTOs;
using Application.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetAllNewsQuery : IRequest<IEnumerable<NewsDTO>>
    {
        
    }
}
