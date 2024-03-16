using Exercicio1.Class;
using Exercicio1.Exceptions;

namespace Exercicio1;

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria contaJoao = new ContaBancaria(12500, "João Gomes");
        ContaBancaria contaMaria = new ContaBancaria(350, "Maria Fernanda");

        // Depositando 500 reais na conta de Maria Fernanda
        contaMaria.Depositar(350);

        // Sacando 500 reais da conta de João Gomes
        contaJoao.Sacar(500);

        // Transferindo 1000 reais da conta de João Gomes para a conta de Maria Fernanda
        contaJoao.Transferir(1000, contaMaria);

        // Gerando erro de saldo insuficiente
        try{
            contaJoao.Sacar(100000);
        }catch(SaldoInsuficienteException e){
            Console.WriteLine("\n" + e.Message);
        }

        // Gerando erro de valor inválido
        try{
            contaMaria.Sacar(0);
        } catch(ValorInvalidoException e){
            Console.WriteLine("\n" + e.Message);
        }
    }
}
