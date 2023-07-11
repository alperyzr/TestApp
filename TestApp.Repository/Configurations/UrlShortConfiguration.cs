using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities;

namespace TestApp.Repository.Configurations
{
    public class UrlShortConfiguration : IEntityTypeConfiguration<UrlShort>
    {
        public void Configure(EntityTypeBuilder<UrlShort> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();

            builder.Property(x=>x.Url).IsRequired();
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.Property(x=>x.Description).HasMaxLength(250);
            builder.HasOne(x => x.User).WithMany(x => x.UrlShorts);

            builder.ToTable("UrlShorts");


        }
    }
}
