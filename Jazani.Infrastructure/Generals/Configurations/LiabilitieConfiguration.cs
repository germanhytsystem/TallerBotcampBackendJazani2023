
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class LiabilitieTypeConfiguration : IEntityTypeConfiguration<Liabilitie>
    {
        public void Configure(EntityTypeBuilder<Liabilitie> builder)
        {
            //throw new NotImplementedException();
            //var toDateTime = new ValueConverter<DateTime, DateTimeOffset>(
            //        dateTime => DateTimeOffset.UtcNow,
            //        dateTimeOffset => dateTimeOffset.DateTime
            //);

            builder.ToTable("liabilities", "lia");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Categoryid).HasColumnName("categoryid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.Year).HasColumnName("year");
            builder.Property(t => t.State).HasColumnName("state");
            builder.Property(t => t.HolderId).HasColumnName("holderid");

            //builder.HasOne(one => one.Holder).WithMany(many => many.Liabilities).HasForeignKey(fk => fk.HolderId);

        }
    }
}
