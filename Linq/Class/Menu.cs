namespace Linq.Class;

public class Menu
{
    public static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1 - Itens de Higiene ordenados por ordem decrescente de preço");
        Console.WriteLine("2 - Itens cujo preço seja maior ou igual a R$ 5,00.");
        Console.WriteLine("3 - Itens cujo tipo seja Comida ou Bebida");
        Console.WriteLine("4 - Quantidade de itens de cada tipo.");
        Console.WriteLine("5 - Preço máximo, mínimo e média de preço de cada tipo.");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
    }
}