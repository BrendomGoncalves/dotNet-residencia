using ExercicioDois.Classes;

namespace ExercicioDois
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("> Passando nenhum parâmetro no construtor:\n- ");
            Data dataHoje = new Data();
            dataHoje.Imprimir(Data.FORMATO_24);

            System.Console.Write("\n> Passando apenas dia, mês e ano no construtor:\n- ");
            Data dataNascimento = new Data(20, 5, 1999);
            dataNascimento.Imprimir(Data.FORMATO_24);

            System.Console.Write("\n> Passando dia, mês, ano, hora, minuto e segundo no construtor (24H):\n- ");
            Data dataAtualUm = new Data(20, 5, 2021, 15, 30, 45);
            dataAtualUm.Imprimir(Data.FORMATO_24);

            System.Console.Write("\n> Passando dia, mês, ano, hora, minuto e segundo no construtor (12H):\n- ");
            Data dataAtualDois = new Data(30, 10, 2019, 2, 30, 45);
            dataAtualDois.Imprimir(Data.FORMATO_24);
        }
    }
}
