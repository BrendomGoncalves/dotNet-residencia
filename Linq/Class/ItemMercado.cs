namespace Linq.Class;

public enum Tipo
{
    Comida = 1,
    Bebida = 2,
    Higiene = 3,
    Limpeza = 4
}

public class ItemMercado
{
    public string? Nome { get; set; }
    public Tipo Tipo { get; set; }
    public double Preco { get; set; }

    public override string ToString()
    {
        return Nome is { Length: > 7 } ? $"{Nome}\t{Tipo}\t\t{Preco}" : $"{Nome}\t\t{Tipo}\t\t{Preco}";
    }
}