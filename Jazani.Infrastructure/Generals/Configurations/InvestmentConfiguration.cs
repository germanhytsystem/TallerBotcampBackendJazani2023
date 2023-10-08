using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            // throw new NotImplementedException();

            builder.ToTable("investment", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Miningconcessionid).HasColumnName("miningconcessionid");
            builder.Property(t => t.Investmenttypeid).HasColumnName("investmenttypeid");
            builder.Property(t => t.Periodtypeid).HasColumnName("periodtypeid");
            builder.Property(t => t.Measureunitid).HasColumnName("measureunitid");
            builder.Property(t => t.Holderid).HasColumnName("holderid");
            builder.Property(t => t.Investmentconceptid).HasColumnName("investmentconceptid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");


            builder.HasOne(one => one.Investmentconcept).WithMany(many => many.Investments).HasForeignKey(fk => fk.Investmentconceptid);
            builder.HasOne(one => one.Miningconcession).WithMany(many => many.Investments).HasForeignKey(fk => fk.Miningconcessionid);
            builder.HasOne(one => one.Periodtype).WithMany(many => many.Investments).HasForeignKey(fk => fk.Periodtypeid);
            builder.HasOne(one => one.Measureunit).WithMany(many => many.Investments).HasForeignKey(fk => fk.Measureunitid);
            builder.HasOne(one => one.Investmenttype).WithMany(many => many.Investments).HasForeignKey(fk => fk.Investmenttypeid);
            builder.HasOne(one => one.Holder).WithMany(many => many.Investments).HasForeignKey(fk => fk.Holderid);


        }
    }
}

