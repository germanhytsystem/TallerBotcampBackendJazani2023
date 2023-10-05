
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        public void Configure(EntityTypeBuilder<Holder> builder)
        {

            builder.ToTable("holder", "soc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.LastName).HasColumnName("lastname");
            builder.Property(t => t.Maidenname).HasColumnName("maidenname");
            builder.Property(t => t.Districtid).HasColumnName("districtid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");


        }
    }
}
