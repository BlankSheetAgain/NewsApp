using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface INewsContext
    {
        public DbSet<News> NewsL { get; set; }
        public DbSet<Comment> Comments { get; set; }

        Task<int> SaveChangesAsync();
    }
}
