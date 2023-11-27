namespace dotNET_P003;

using System.Diagnostics;

class Estoque
{
    public Estoque()
    {
        listaProdutos = new List<Produto>();
        this.ultimoCodigo = 0;
    }

    private List<Produto> listaProdutos;
    private int ultimoCodigo { get; set; }

    public int QuantidadeProdutos()
    {
        return listaProdutos.Count;
    }

    public void AdicionarProduto(Produto p)
    {
        p.codigo = ++ultimoCodigo;
        listaProdutos.Add(p);
    }

    public void ConsultarProduto(int id)
    {
        var produto = listaProdutos.Find(p => p.codigo == id);
        if (produto != null)
        {
            Console.WriteLine($"Nome: {produto.nome}");
            Console.WriteLine($"Preço Unitário: {produto.precoUnitario}");
            Console.WriteLine($"Quantidade em Estoque: {produto.quantidadeEstoque}");
        }
        else
        {
            throw new Exception("Produto nao encontrado, verifique o id digitado.");
        }
    }

    public void AtualizarEstoque(int codigo, int quantidade)
    {
        var produto = listaProdutos.Find(p => p.codigo == codigo);
        if (produto != null)
        {
            if (produto.quantidadeEstoque < quantidade)
            {
                throw new Exception("Quantidade em estoque insuficiente.");
            }
            else produto.quantidadeEstoque += quantidade;
        }
        else
        {
            throw new Exception("Produto nao encontrado, verifique o id digitado.");
        }
    }

    public void GerarRelatorios()
    {
        if (listaProdutos.Count <= 0) Console.WriteLine("Nenhum produto cadastrado.");
        else
        {
            int op;
            Console.WriteLine("RELATORIOS");
            Console.WriteLine("[1] Relatório de quantidade");
            Console.WriteLine("[2] Relatório de valor");
            Console.WriteLine("[3] Relatório de total");
            Console.WriteLine("[4] Voltar");
            if (!int.TryParse(Console.ReadLine(), out op))
            {
                throw new Exception("Opção inválida! Digite entre 1 e 4.");
            }
            else
            {
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        int valor;
                        Console.WriteLine("Relatório de Quantidade");
                        Console.WriteLine("Digite o valor mínimo em estoque:");
                        if (!int.TryParse(Console.ReadLine(), out valor))
                        {
                            throw new Exception("Somente numeros sao aceitos.");
                        }
                        else
                        {
                            List<Produto> produtosRelatorio =
                                (from produto in listaProdutos
                                    where produto.quantidadeEstoque <= valor
                                    select produto).ToList();
                            if (produtosRelatorio.Count == 0)
                            {
                                Console.WriteLine("Nenhum resultado encontrado.");
                            }
                            else
                            {
                                foreach (var item in produtosRelatorio)
                                {
                                    Console.WriteLine($"Nome: {item.nome}");
                                    Console.WriteLine($"Preço Unitário: {item.precoUnitario}");
                                    Console.WriteLine($"Quantidade em Estoque: {item.quantidadeEstoque}\n");
                                }
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Relatório de valor");
                        int valorMax, valorMin;
                        Console.WriteLine("Digite o teto mínimo e máximo:");
                        Console.Write("Minimo: ");
                        if (!int.TryParse(Console.ReadLine(), out valorMin))
                        {
                            throw new Exception("Somente numeros sao aceitos.");
                        }
                        else
                        {
                            if (!int.TryParse(Console.ReadLine(), out valorMax))
                            {
                                throw new Exception("Somente numeros sao aceitos.");
                            }
                            else
                            {
                                List<Produto> produtosRelatorio =
                                    (from produto in listaProdutos
                                        where produto.quantidadeEstoque >= valorMin &&
                                              produto.quantidadeEstoque <= valorMax
                                        select produto).ToList();
                                if (produtosRelatorio.Count == 0)
                                {
                                    Console.WriteLine("Nenhum resultado encontrado.");
                                }
                                else
                                {
                                    foreach (var item in produtosRelatorio)
                                    {
                                        Console.WriteLine($"Nome: {item.nome}");
                                        Console.WriteLine($"Preço Unitário: {item.precoUnitario}");
                                        Console.WriteLine($"Quantidade em Estoque: {item.quantidadeEstoque}\n");
                                    }
                                }
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("Relatório de total");
                        Console.WriteLine("Total em Estoque: " +
                                          listaProdutos.Sum(p => p.precoUnitario * p.quantidadeEstoque));
                        foreach (Produto p in listaProdutos)
                        {
                            Console.WriteLine($"Nome: {p.nome}");
                            Console.WriteLine("Total em Estoque: " + p.precoUnitario * p.quantidadeEstoque);
                        }

                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Digite entre 1 e 4.");
                        break;
                }
            }
        }
    }
}