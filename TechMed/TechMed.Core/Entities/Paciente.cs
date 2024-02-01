namespace TechMed.Core.Entities;

public class Paciente : Pessoa
{
    public int PacienteId {get; set;}
    public DateTimeOffSet DataNascimento {get; set;}
}
