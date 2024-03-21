using Linq.Class;

namespace Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int option;
        var listaItens = PopulaLista();
        do
        {
            Menu.ShowMenu();
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Relarotios.HigieneDecrescente(ref listaItens);
                    break;
                case 2:
                    Relarotios.ItensPorPrecoCrescente(ref listaItens);
                    break;
                case 3:
                    Relarotios.ItensBebidaComida(ref listaItens);
                    break;
                case 4:
                    Relarotios.QuantidadePorCategoria(ref listaItens);
                    break;
                case 5:
                    Relarotios.CategoriaPorPrecoMaxMinMed(ref listaItens);
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    break;
            }
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (option != 0);
    }
    private static List<ItemMercado> PopulaLista()
    {
        return new List<ItemMercado>
        {
            new() { Nome = "Arroz", Tipo = Tipo.Comida, Preco = 3.90 },
            new() { Nome = "Azeite", Tipo = Tipo.Comida, Preco = 2.50 },
            new() { Nome = "Macarrão", Tipo = Tipo.Comida, Preco = 3.90 },
            new() { Nome = "Cerveja", Tipo = Tipo.Bebida, Preco = 22.90 },
            new() { Nome = "Refrigerante", Tipo = Tipo.Bebida, Preco = 5.50 },
            new() { Nome = "Shampoo", Tipo = Tipo.Higiene, Preco = 7.00 },
            new() { Nome = "Sabonete", Tipo = Tipo.Higiene, Preco = 2.40 },
            new() { Nome = "Cotonete", Tipo = Tipo.Higiene, Preco = 5.70 },
            new() { Nome = "Sabão em pó", Tipo = Tipo.Limpeza, Preco = 8.20 },
            new() { Nome = "Detergente", Tipo = Tipo.Limpeza, Preco = 2.60 },
            new() { Nome = "Amaciante", Tipo = Tipo.Limpeza, Preco = 6.40 }
        };
    }
}