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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Role);
            
            builder.ToTable("UserRoles");
        }
    }
}
