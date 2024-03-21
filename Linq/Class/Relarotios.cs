namespace Linq.Class;

public static class Relarotios
{
    public static void HigieneDecrescente(ref List<ItemMercado> listaItens)
    {
        Console.Clear();
        Console.WriteLine("Produtos de HIGIENE:");
        listaItens
            .Where(produto => produto.Tipo == Tipo.Higiene)
            .OrderByDescending(produtoOrdem => produtoOrdem.Preco)
            .ToList()
            .ForEach(produtoHigiene => Console.WriteLine(produtoHigiene.ToString())
            );
    }
    
    public static void ItensPorPrecoCrescente(ref List<ItemMercado> listaItens)
    {
        Console.Clear();
        Console.WriteLine("Lista de itens do mercado por preço:");
        Console.WriteLine("Digite o preço máximo que deseja listar:");
        Console.Write("> ");
        var preco = Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine($"Produtos com preço de no mínimo R$ {preco}:\n");
        listaItens
            .Where(produto => produto.Preco >= preco)
            .OrderBy(x => x.Preco)
            .ToList()
            .ForEach(produtoPreco => Console.WriteLine(produtoPreco.ToString())
            );
    }

    public static void ItensBebidaComida(ref List<ItemMercado> listaItens)
    {
        Console.Clear();
        Console.WriteLine("Lista de COMIDA e BEBIDA:");
        listaItens
            .Where(produto => produto.Tipo == Tipo.Comida || produto.Tipo == Tipo.Bebida)
            .OrderBy(x => x.Nome)
            .ToList()
            .ForEach(produtoTipo => Console.WriteLine(produtoTipo.ToString())
            );
    }

    public static void QuantidadePorCategoria(ref List<ItemMercado> listaItens)
    {
        Console.Clear();
        Console.WriteLine("Quantidade de itens por categoria:");
        var quantidadePorCategoria = listaItens
            .GroupBy(produto => produto.Tipo)
            .Select(grupo => new
            {
                Categoria = grupo.Key,
                Quantidade = grupo.Count()
            });
        quantidadePorCategoria
            .ToList()
            .ForEach(categoria => 
                Console.WriteLine($"{categoria.Categoria}: {categoria.Quantidade}")
            );
    }

    public static void CategoriaPorPrecoMaxMinMed(ref List<ItemMercado> listaItens)
    {
        Console.Clear();
        var precoPorTipo = listaItens
            .GroupBy(produto => produto.Tipo)
            .Select(grupo => new
            {
                Categoria = grupo.Key,
                PrecoMaximo = grupo.Max(x => x.Preco),
                PrecoMinimo = grupo.Min(x => x.Preco),
                PrecoMedio = grupo.Average(x => x.Preco)
            });
        Console.WriteLine("Preço máximo, mínimo e médio por categoria:");
        Console.WriteLine("Categoria\tMáximo\tMínimo\tMédio");
        Console.WriteLine("---------\t------\t------\t-----");
        precoPorTipo
            .ToList()
            .ForEach(categoria => 
                Console.WriteLine($"{categoria.Categoria}\t\t{categoria.PrecoMaximo}\t{categoria.PrecoMinimo}\t{categoria.PrecoMedio:F2}")
            );
    }
}