namespace Semana_4.AvaliacaoIndividual;

public class Academia
{
    private List<Treinador> treinadores = new List<Treinador>();
    private List<Cliente> clientes = new List<Cliente>();

    public void AdicionarTreinador(Treinador t)
    {
        foreach (var treinador in treinadores)
        {
            if (treinador.Cpf == t.Cpf)
            {
                throw new Exception("Treinador ja existe!");
            }
        }
        treinadores.Add(t);
    }
    public void AdicionarCliente(Cliente c)
    {
        foreach (var cliente in clientes)
        {
            if (cliente.Cpf == c.Cpf)
            {
                throw new Exception("Cliente ja existe!");
            }
        }
        clientes.Add(c);
    }

    public void TreinadoresEntreIdades(int idadeMin, int idadeMax)
    {
        DateTime now = DateTime.Today;
        List<Treinador> treinadoresIdadeValida = treinadores.Where(t =>
        {
            int age = now.Year - t.DataNascimento.Year;
            if (t.DataNascimento.Date > now.AddYears(-age)) age--;
            return age >= idadeMin && age <= idadeMax;
        }).ToList();

        foreach (var treinador in treinadoresIdadeValida)
        {
            Console.WriteLine("  - " + treinador.Nome + " (" + treinador.DataNascimento.ToString("dd/MM/yyyy") + ")");
        }
    }
    public void ClientesEntreIdades(int idadeMin, int idadeMax){
        DateTime now = DateTime.Today;
        List<Cliente> clientesIdadeValida = clientes.Where(c =>
        {
            int age = now.Year - c.DataNascimento.Year;
            if (c.DataNascimento.Date > now.AddYears(-age)) age--;
            return age >= idadeMin && age <= idadeMax;
        }).ToList();

        foreach (var cliente in clientesIdadeValida)
        {
            Console.WriteLine("  - " + cliente.Nome + " (" + cliente.DataNascimento.ToString("dd/MM/yyyy") + ")");
        }
    }
    public void ClientesIMC(double imc)
    {
        List<Cliente> clientesIMC = clientes.Where(c => (c.Peso / Math.Pow(c.Altura, 2)) > imc)
                                            .OrderBy(c => c.Peso / Math.Pow(c.Altura, 2))
                                            .ToList();

        foreach (var cliente in clientesIMC)
        {
            Console.WriteLine("  - " + cliente.Nome + " (" + string.Format("{0:0.00}", cliente.Peso / Math.Pow(cliente.Altura, 2)) + ")");
        }
    }
    public void ClientesLista(){
        List<Cliente> clientesLista = clientes.OrderBy(c => c.Nome).ToList();

        foreach (var cliente in clientesLista)
        {
            Console.WriteLine("  - " + cliente.Nome);
        }
    }
    public void ClientesIdadeDecrescente(){
        List<Cliente> clientesDecrescente = clientes.OrderBy(c => c.DataNascimento).ToList();

        foreach (var cliente in clientesDecrescente)
        {
            Console.WriteLine("  - " + cliente.Nome + " (" + cliente.DataNascimento.ToString("dd/MM/yyyy") + ")");
        }
    }
    public void UsuarioAniversario(int mes){
        List<Cliente> clientesAniversario = clientes.Where(c => c.DataNascimento.Month == mes).ToList();

        foreach (var cliente in clientesAniversario)
        {
            Console.WriteLine("  - " + cliente.Nome + " (" + cliente.DataNascimento.ToString("dd/MM/yyyy") + ")");
        }
    }
}