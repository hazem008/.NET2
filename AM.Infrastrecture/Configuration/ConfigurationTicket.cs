using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AM.Infrastrecture.Configuration
{
    public class ConfigurationTicket : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PassangerFK, t.FlightFK});
            builder.HasOne(p => p.passenger).WithMany(m => m.tickets).HasForeignKey(t => t.PassangerFK);
            builder.HasOne(p => p.Flight).WithMany(m => m.tickets).HasForeignKey(t => t.FlightFK);
        }
    }
}
