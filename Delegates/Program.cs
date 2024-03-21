namespace Delegates;

public class Program
{
    public static void Main(string[] args)
    {
        var elementosDouble = new List<double>{ 3, 7, 2, 4, 6 };
        var elementosConvertidos = elementosDouble.ConvertAll(x => x/2);
        elementosConvertidos.ForEach(Console.WriteLine);
    }
}