using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Comments).WithOne(x => x.News);
            builder.HasOne(x => x.User).WithMany(x => x.News);
            builder.Property(x=>x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x=>x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();

        }
    }
}
