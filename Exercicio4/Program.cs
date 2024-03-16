namespace Exercicio4;

using Exercicio4.Class;
using Exercicio4.Class.Interface;

public class Program
{
    public static void Main(string[] args)
    {
        ServicoFabrica<ServicoCatalogar> fabrica = new ServicoFabrica<ServicoCatalogar>();
        IServico servico = fabrica.NovaInstancia();
        servico.Executar();
    }
}
