namespace dotNET_P003;
class Produto
{
  public Produto() { }
  public Produto(string nome, double preco, int quantidade)
  {
    this.nome = nome;
    this.precoUnitario = preco;
    this.quantidadeEstoque = quantidade;
  }
  public int codigo { get; set; }
  public string? nome { get; set; }
  public double precoUnitario { get; set; }
  public int quantidadeEstoque { get; set; }

  public void Cadastrar()
  {
    Console.WriteLine("CADASTRO DE PRODUTOS");
    try
    {
      Console.Write("Nome do Produto: ");
      this.nome = Console.ReadLine();
      if (string.IsNullOrEmpty(this.nome))
      {
        throw new Exception("Nome do produto não pode ser vazio ou nulo.");
      }

      Console.Write("Preço Unitário: ");
      if (!double.TryParse(Console.ReadLine(), out double _precoUnitario))
      {
        throw new FormatException("Preço unitário deve ser um número.");
      }
      this.precoUnitario = _precoUnitario;

      Console.Write("Quantidade em Estoque: ");
      if (!int.TryParse(Console.ReadLine(), out int _quantidadeEstoque))
      {
        throw new FormatException("Quantidade em estoque deve ser um número inteiro.");
      }
      this.quantidadeEstoque = _quantidadeEstoque;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
  }
}