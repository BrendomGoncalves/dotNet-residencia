namespace techmed.Domain.Entities;

public class Exame{
    public int ExameId {get; set;}
    public required string Titulo {get; set;}
    public decimal Valor {get; set;}
    public string? Descricao {get; set;}
    public required int AtendimentoId {get; set;}
    public required Atendimento Atendimento {get; set;}
}

