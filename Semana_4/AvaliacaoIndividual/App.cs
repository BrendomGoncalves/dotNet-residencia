namespace Semana_4.AvaliacaoIndividual;
public class App
{
    public static void Main(string[] args)
    {
        Academia academia = new Academia();

        try
        {
            Treinador treinador1 = new Treinador("Joao", new DateTime(2000, 5, 20), "12345678900", "123456789");
            Treinador treinador2 = new Treinador("Bruno", new DateTime(1984, 10, 11), "12341234123", "987654321");
            Treinador treinador3 = new Treinador("Alessandro", new DateTime(2001, 10, 20), "09876543210", "123412345");
            academia.AdicionarTreinador(treinador1);
            academia.AdicionarTreinador(treinador2);
            academia.AdicionarTreinador(treinador3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Cliente cliente1 = new Cliente("Marcelo", new DateTime(1999, 8, 10), "12345678901", 1.78, 110);
            Cliente cliente2 = new Cliente("Luiza", new DateTime(2005, 5, 5), "12345678902", 1.80, 84);
            Cliente cliente3 = new Cliente("Mariele", new DateTime(1998, 1, 1), "12345678903", 1.65, 65);
            academia.AdicionarCliente(cliente1);
            academia.AdicionarCliente(cliente2);
            academia.AdicionarCliente(cliente3);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("Treinadores com idade entre dois valores:");
        academia.TreinadoresEntreIdades(10, 35);
        Console.WriteLine("Clientes com idade entre dois valores:");
        academia.ClientesEntreIdades(15, 20);
        Console.WriteLine("Clientes com IMC maior que um valor informado, em ordem crescente:");
        academia.ClientesIMC(19);
        Console.WriteLine("Clientes em ordem alfabética:");
        academia.ClientesLista();
        Console.WriteLine("Clientes do mais velho para mais novo:");
        academia.ClientesIdadeDecrescente();
        Console.WriteLine("Treinadores e clientes aniversariantes do mês informado:");
        academia.UsuarioAniversario(5);
    }
}