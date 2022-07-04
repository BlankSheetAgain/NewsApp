using Application.Interfaces;
using Domain.Entities;
using Domain.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class NewsContext : IdentityDbContext<ApplicationUser>, INewsContext
    {
        public DbSet<News> NewsL { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
