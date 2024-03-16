namespace Exercicio5;

using Exercicio5.Class;

public class Program
{
    public static void Main(string[] args)
    {
        Triangulo<int> trianguloInt = new Triangulo<int>
        {
            P1 = new Ponto<int> { X = 1, Y = 2, Z = 3 },
            P2 = new Ponto<int> { X = 4, Y = 5, Z = 6 },
            P3 = new Ponto<int> { X = 7, Y = 8, Z = 9 }
        };

        Triangulo<double> trianguloDouble = new Triangulo<double>
        {
            P1 = new Ponto<double> { X = 1.1, Y = 2.2, Z = 3.3 },
            P2 = new Ponto<double> { X = 4.4, Y = 5.5, Z = 6.6 },
            P3 = new Ponto<double> { X = 7.7, Y = 8.8, Z = 9.9 }
        };

        Triangulo<decimal> trianguloDecimal = new Triangulo<decimal>
        {
            P1 = new Ponto<decimal> { X = 1.1m, Y = 2.2m, Z = 3.3m },
            P2 = new Ponto<decimal> { X = 4.4m, Y = 5.5m, Z = 6.6m },
            P3 = new Ponto<decimal> { X = 7.7m, Y = 8.8m, Z = 9.9m }
        };

        Console.WriteLine("Triangulo<int>");
        Console.WriteLine($"P1: {trianguloInt.P1.X}, {trianguloInt.P1.Y}, {trianguloInt.P1.Z}");
        Console.WriteLine($"P2: {trianguloInt.P2.X}, {trianguloInt.P2.Y}, {trianguloInt.P2.Z}");
        Console.WriteLine($"P3: {trianguloInt.P3.X}, {trianguloInt.P3.Y}, {trianguloInt.P3.Z}");

        Console.WriteLine("Triangulo<double>");
        Console.WriteLine($"P1: {trianguloDouble.P1.X}, {trianguloDouble.P1.Y}, {trianguloDouble.P1.Z}");
        Console.WriteLine($"P2: {trianguloDouble.P2.X}, {trianguloDouble.P2.Y}, {trianguloDouble.P2.Z}");
        Console.WriteLine($"P3: {trianguloDouble.P3.X}, {trianguloDouble.P3.Y}, {trianguloDouble.P3.Z}");

        Console.WriteLine("Triangulo<decimal>");
        Console.WriteLine($"P1: {trianguloDecimal.P1.X}, {trianguloDecimal.P1.Y}, {trianguloDecimal.P1.Z}");
        Console.WriteLine($"P2: {trianguloDecimal.P2.X}, {trianguloDecimal.P2.Y}, {trianguloDecimal.P2.Z}");
        Console.WriteLine($"P3: {trianguloDecimal.P3.X}, {trianguloDecimal.P3.Y}, {trianguloDecimal.P3.Z}");
    }
}
