using System.Reflection;

using Application.Interfaces;
using Domain.Entities;
using Domain.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class NewsContext : IdentityDbContext<ApplicationUser>, INewsContext
    {
        public DbSet<News> NewsL { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options) 
        {
        Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            
        }


        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
