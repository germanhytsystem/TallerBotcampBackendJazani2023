
using Jazani.Domain.Generals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class LiabilitieTypeConfiguration : IEntityTypeConfiguration<LiabilitieType>
    {
        public void Configure(EntityTypeBuilder<LiabilitieType> builder)
        {
            //throw new NotImplementedException();
            var toDateTime = new ValueConverter<DateTime, DateTimeOffset>(
                    dateTime => DateTimeOffset.UtcNow,
                    dateTimeOffset => dateTimeOffset.DateTime
            );

            builder.ToTable("liabilities", "lia");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Categoryid).HasColumnName("categoryid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(toDateTime);
            builder.Property(t => t.Year).HasColumnName("year");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
