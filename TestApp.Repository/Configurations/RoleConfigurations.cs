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
    public class RoleConfigurations: IEntityTypeConfiguration<Role>
    {
       
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=> x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);

            builder.HasMany(x => x.Users).WithMany(x => x.Roles);

            builder.ToTable("Roles");
        }
    }
}
