using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class NewsContext : DbContext, INewsContext
    {
        public DbSet<News> NewsL { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
