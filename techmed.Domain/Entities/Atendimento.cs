namespace techmed.Domain.Entities;

public class Atendimento{
    public int AtendimentoId {get; set;}
    public required DateTime DataHora {get; set;}
    public required string Suspeita {get; set;}
    public string? Diagnostico {get; set;}
    public required int MedicoId {get; set;}
    public required Medico Medico {get; set;}
    public required int PacienteId {get; set;}
    public required Paciente Paciente {get; set;}

    public ICollection<Exame>? Exames {get; set;}
}
