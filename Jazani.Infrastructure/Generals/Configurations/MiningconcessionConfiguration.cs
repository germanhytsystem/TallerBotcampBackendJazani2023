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
    public class MiningconcessionConfiguration : IEntityTypeConfiguration<Miningconcession>
    {
        public void Configure(EntityTypeBuilder<Miningconcession> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("miningconcession", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Code).HasColumnName("code");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("resgitrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

        }

    }
}

