namespace dotNET_P003;

class App
{
    public static void Pausa()
    {
        Console.Write("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private static int Menu()
    {
        int x;
        Console.WriteLine("ESTOQUE RESIDENCIA LTDA");
        Console.WriteLine("[1] Cadastrar Novo Produto");
        Console.WriteLine("[2] Consultar Produto Por Id");
        Console.WriteLine("[3] Atualizar Estoque");
        Console.WriteLine("[4] Gerar Relatorios");
        Console.Write("[5] Sair\n> ");
        return int.TryParse(Console.ReadLine(), out x) ? x : 0;
    }

    static void Main(string[] args)
    {
        Estoque estoque = new Estoque();
        int op;
        do
        {
            Console.Clear();
            op = Menu();
            switch (op)
            {
                case 1:
                    Console.Clear();
                    Produto p = new Produto();
                    p.Cadastrar();
                    if (string.IsNullOrEmpty(p.nome) || p.precoUnitario == 0 || p.quantidadeEstoque == 0)
                    {
                        Console.Write("\nCadastro Cancelado!\n\n");
                    }
                    else
                    {
                        estoque.AdicionarProduto(p);
                        Console.Write("\nProduto Cadastrado!\n\n");
                    }

                    Pausa();
                    break;
                case 2:
                    try
                    {
                        int id;
                        Console.Clear();
                        if (estoque.QuantidadeProdutos() > 0)
                        {
                            Console.WriteLine("CONSULTA DE PRODUTO");
                            Console.Write("Digite o ID do Produto: ");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                estoque.ConsultarProduto(id);
                            }
                            else
                            {
                                Console.WriteLine("ID Invalido!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum produto cadastrado!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Pausa();
                    break;
                case 3:
                    try
                    {
                        Console.Clear();
                        if (estoque.QuantidadeProdutos() > 0)
                        {
                            Console.WriteLine("ATUALIZAR ESTOQUE");
                            Console.Write("Digite o ID do produto: ");
                            int idProduto, qtd;
                            if (int.TryParse(Console.ReadLine(), out idProduto))
                            {
                                //estoque.ConsultarProduto(idProduto);
                                Console.WriteLine("Utilize o operador (-) para indicar retirada:");
                                Console.Write("Quantidade: ");
                                if (int.TryParse(Console.ReadLine(), out qtd))
                                    estoque.AtualizarEstoque(idProduto, qtd);
                                else Console.WriteLine("Quantidade Invalida!");
                            }
                            else Console.WriteLine("ID Invalido!");
                        }
                        else Console.WriteLine("Nenhum produto cadastrado!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Pausa();
                    break;
                case 4:
                    try
                    {
                        Console.Clear();
                        estoque.GerarRelatorios();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Pausa();
                    break;
                case 5:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    if (op == 0)
                        Console.WriteLine("Digite um numero entre 1 e 5!");
                    else
                        Console.WriteLine("Essa opcao não existe!");
                    Pausa();
                    break;
            }
        } while (op != 5);
    }
}