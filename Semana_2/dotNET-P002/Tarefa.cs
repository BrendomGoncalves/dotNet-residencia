public class Tarefa
{
  private string? titulo;
  private string? descricao;
  private DateTime dataVencimento;
  private bool statusConclusao;
  public Tarefa()
  {
    this.statusConclusao = false;
  }
  public Tarefa(string? _titulo, string? _descricao, DateTime _dataVencimento, bool _statusConclusao)
  {
    this.titulo = _titulo;
    this.descricao = _descricao;
    this.dataVencimento = _dataVencimento;
    this.statusConclusao = _statusConclusao;
  }
  public string? Titulo
  {
    get { return titulo; }
    set { titulo = value; }
  }
  public string? Descricao
  {
    get { return descricao; }
    set { descricao = value; }
  }
  public DateTime DataVencimento
  {
    get { return dataVencimento; }
    set { dataVencimento = value; }
  }
  public bool StatusConclusao
  {
    get { return statusConclusao; }
    set { statusConclusao = value; }
  }
  public void criarTarefa(){
    int dia, mes, ano, hora, minutos;
    char? opcao;

    Console.Clear();
    Console.WriteLine("obs: Deixe vazio para cancelar e voltar");
    Console.Write("Digite o título da tarefa: ");
    this.titulo = Console.ReadLine();

    if(this.titulo == "" || this.titulo == null || this.titulo == " ") return;

    Console.Write("Digite a descrição da tarefa: ");
    this.descricao = Console.ReadLine();

    if(this.descricao == "" || this.descricao == null || this.descricao == " ") this.descricao = "Sem descrição";

    Console.WriteLine("Digite a data de vencimento da tarefa: ");
    Console.Write("Dia: ");
    int.TryParse(Console.ReadLine(), out dia);
    Console.Write("Mes: ");
    int.TryParse(Console.ReadLine(), out mes);
    Console.Write("Ano: ");
    int.TryParse(Console.ReadLine(), out ano);
    Console.WriteLine("Digite a hora: ");
    Console.Write("Hora: ");
    int.TryParse(Console.ReadLine(), out hora);
    Console.Write("Minuto: ");
    int.TryParse(Console.ReadLine(), out minutos);

    this.dataVencimento = new DateTime(ano, mes, dia, hora, minutos, 0);
    
    System.Console.Write("Esta tarefa já foi concluida? [S/N]\n> ");
    opcao = Console.ReadKey().KeyChar;
    if (opcao == 'S' || opcao == 's') this.statusConclusao = true;
    else this.statusConclusao = false;
  }
}