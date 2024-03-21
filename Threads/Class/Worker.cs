namespace Threads.Class;

public class Worker
{
    private readonly string _name;

    public Worker(string name)
    {
        _name = name;
    }

    public void Work()
    {
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine($"{_name} está em {i * 10}%");
            Thread.Sleep(1000);
        }
    }
}