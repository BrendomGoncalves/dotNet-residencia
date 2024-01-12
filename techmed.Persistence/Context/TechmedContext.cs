using techmed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace techmed.Persistence.Context;

public class TechMedContext : DbContext
{
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=Bvg@2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medico>().ToTable("Medicos")
            .HasKey(m => m.MedicoId);
        modelBuilder.Entity<Paciente>().ToTable("Pacientes")
            .HasKey(p => p.PacienteId);
        modelBuilder.Entity<Atendimento>().ToTable("Atendimentos")
            .HasKey(a => a.AtendimentoId);
        modelBuilder.Entity<Paciente>()
            .HasMany(p => p.Atendimentos)
            .WithOne(a => a.Paciente)
            .HasForeignKey(a => a.PacienteId);
    }
}
