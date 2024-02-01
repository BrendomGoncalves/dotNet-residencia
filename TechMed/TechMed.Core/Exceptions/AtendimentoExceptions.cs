namespace TechMed.Core.Exceptions;

public class AtendimentoExceptions : Exception
{
    public AtendimentoNotFoundException() : base("Atendimento não encontrado.") {}
}
