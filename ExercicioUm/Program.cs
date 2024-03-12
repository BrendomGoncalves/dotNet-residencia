using ExercicioUm.Classes;

namespace ExercicioUm
{
    public class Program
    {
        Lampada lampadaSala = new Lampada(true);
        Lampada lampadaCozinha = new Lampada(false);

        System.Console.WriteLine("Estado das lâmpadas:");
        lampadaSala.ImprimirEstado();
        lampadaCozinha.ImprimirEstado();
    }
}
