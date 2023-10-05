using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class LiabilitieDocumentConfiguration : IEntityTypeConfiguration<LiabilitieDocument>
    {
        public void Configure(EntityTypeBuilder<LiabilitieDocument> builder)
        {
            //throw new NotImplementedException();

            builder.ToTable("liabilitiesdocument", "lia");
            builder.HasKey(t => t.DocumentId);
            builder.Property(t => t.liabilitiesid).HasColumnName("liabilitiesid");
            builder.Property(t => t.Folios).HasColumnName("folios");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("resgitrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.Liabilitie).WithMany(many => many.LiabilitieDocuments).HasForeignKey(fk=>fk.liabilitiesid);
        }
    }
}
