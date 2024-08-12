using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Domain.UserAggregate;
using Dinely.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinely.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );

            builder.Property(u => u.FirstName)
                .HasMaxLength(20);

            builder.Property(u => u.LastName)
                .HasMaxLength(20);
        }

    }
}