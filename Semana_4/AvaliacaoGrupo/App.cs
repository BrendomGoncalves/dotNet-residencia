namespace Avaliacao;

public class App
{
    public static void Main()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu da academia:");
            Console.WriteLine("1. Gerenciar Treino");
            Console.WriteLine("2. Gerenciar Exercicios");
            Console.WriteLine("3. Gerenciar Treinador");
            Console.WriteLine("4. Gerenciar Cliente");
            Console.WriteLine("0. Sair");
            Console.Write("> ");
            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("== Gerenciar Treino ==");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("== Gerenciar Exercícios ==");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("== Gerenciar Treinador ==");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("== Gerenciar Cliente ==");
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Pausa();
                    break;
            }
        } while (opcao != 0);
    }
    public static void Pausa()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}