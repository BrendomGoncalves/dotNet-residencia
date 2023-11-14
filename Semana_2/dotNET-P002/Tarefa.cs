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
  public DateTime DataConclusao
  {
    get { return dataVencimento; }
    set { dataVencimento = value; }
  }
  public bool StatusConclusao
  {
    get { return statusConclusao; }
    set { statusConclusao = value; }
  }
}