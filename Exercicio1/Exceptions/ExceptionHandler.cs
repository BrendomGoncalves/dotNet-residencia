namespace Exercicio1.Exceptions;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(double saldo) : base($"Operação Cancelada: Saldo insuficiente: {saldo}"){}
}

public class ValorInvalidoException : Exception
{
    public ValorInvalidoException(double valor) : base($"Operação Cancelada: Valor {valor} eh inválido"){}
}
