using Threads.Class;

namespace Threads;

public class Program
{
    static void Main(string[] args)
    {
        var primeiro = new Worker("Trabalho 1");
        var segundo = new Worker("Trabalho 2");

        var threadUm = new Thread(primeiro.Work);
        var threadDois = new Thread(segundo.Work);

        threadUm.Start();
        threadDois.Start();

        threadUm.Join();
        threadDois.Join();

        Console.WriteLine("Todos os trabalhos foram finalizados!");
    }
}