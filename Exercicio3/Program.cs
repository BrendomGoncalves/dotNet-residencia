namespace Exercicio3;

class Program
{
    enum Exercicio
    {
        Academia = 1,
        Luta = 2,
        Corrida = 3
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha um exercício para praticar:");
            Console.WriteLine("1 - Academia");
            Console.WriteLine("2 - Luta");
            Console.WriteLine("3 - Corrida");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            int opcao;
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                opcao = -1;
                continue;
            }

            if (opcao == 0) break;
            if (opcao < 1 || opcao > 3)
            {
                Console.WriteLine("Opção inválida.");
                Console.Write("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }
            Console.WriteLine($"Você escolheu: {((Exercicio)opcao).ToString()}.");
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
