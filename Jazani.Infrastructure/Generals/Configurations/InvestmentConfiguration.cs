using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}

