using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jazani.Domain.Admins.Models;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class LiabilitieConfiguration : IEntityTypeConfiguration<Liabilitie>
    {

        // Método de configuración que establece cómo se mapea la entidad Liabilitie a la base de datos
        public void Configure(EntityTypeBuilder<Liabilitie> builder)
        {
            builder.ToTable("liabilities", "lia");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Categoryid).HasColumnName("categoryid");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.Year).HasColumnName("year");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}

