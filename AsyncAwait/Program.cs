namespace AsyncAwait;

class Program
{
    static async Task Main(string[] args)
    {
        var task1 = DoWorkAsync("Tarefa 1", 5);
        var task2 = DoWorkAsync("Tarefa 2", 7);

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Ambas as tarefas foram concluídas!");
    }

    private static async Task DoWorkAsync(string taskName, int delay)
    {
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine($"{taskName} está em {i * 10}%");
            await Task.Delay(delay * 1000);
        }
    }
}