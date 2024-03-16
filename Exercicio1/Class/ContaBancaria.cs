using Exercicio1.Exceptions;

namespace Exercicio1.Class;

public class ContaBancaria{

    // Fields
    public string NomePublico { get; set; }
    public double Saldo { get; private set; }

    // Constructor
    public ContaBancaria(double saldo, string nomePublico = "Conta Bancária"){
        Saldo = saldo;
        NomePublico = nomePublico;
    }

    // Methods
    public void Sacar(double valor){
        if(valor <= 0) throw new ValorInvalidoException(valor);
        if(valor > Saldo) throw new SaldoInsuficienteException(Saldo);
        Saldo -= valor;
        Console.WriteLine($"\n{NomePublico}, seu saque de {valor} foi realizado com sucesso.");
        Console.WriteLine($"- Saldo atual: {Saldo}");
    }
    public void Depositar(double valor){
        if(valor <= 0) throw new ValorInvalidoException(valor);
        Saldo += valor;
        Console.WriteLine($"\n{NomePublico}, seu depósito de {valor} foi realizado com sucesso.");
        Console.WriteLine($"+ Saldo atual: {Saldo}");
    }
    public void Transferir(double valor, ContaBancaria contaDestino){
        if(valor <= 0) throw new ValorInvalidoException(valor);
        if(valor > Saldo) throw new SaldoInsuficienteException(Saldo);
        Sacar(valor);
        contaDestino.Depositar(valor);
        Console.WriteLine($"\n{NomePublico}, sua transferência de {valor} foi realizada com sucesso para {contaDestino.NomePublico}.");
        Console.WriteLine($"- Saldo atual: {Saldo}");
    }
}
