using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastrecture.Configuration
{
    public class PassegerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, f =>
            {
                f.Property(h=>h.FirstName).IsRequired().HasMaxLength(30).HasColumnName("FirstName");
                f.Property(h=>h.LastName).IsRequired().HasMaxLength(30).HasColumnName("LastName");
            });
            builder.HasDiscriminator<int>("Type").HasValue<Passenger>(04).HasValue<Staff>(19).HasValue<Traveller>(1999);
        }
    }
}
