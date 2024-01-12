namespace techmed.Domain.Entities;

public class Medico : Pessoa{
    public int MedicoId {get; set;}
    public required string CRM {get; set;}
    public string? Especialidade {get; set;}
    public required decimal Salario {get; set;}
}
