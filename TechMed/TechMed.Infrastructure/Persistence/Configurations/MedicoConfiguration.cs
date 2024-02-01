using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Core.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
{
   public void Configure(EntityTypeBuilder<Medico> builder)
   {
      builder
         .ToTable("Medicos")
         .HasKey(m => m.MedicoId);
   }
}
