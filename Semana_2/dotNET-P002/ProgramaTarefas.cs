using System.Globalization;
class ProgramaTarefas
{
  private static List<Tarefa> tarefas = new List<Tarefa>();
  static void Main()
  {
    char opcao;
    do
    {
      Console.Clear();
      Console.WriteLine("GERENCIADOR DE TAREFAS");
      Console.WriteLine("1. Nova Tarefa");
      Console.WriteLine("2. Listar Todas as Tarefas");
      Console.Write("5. Exit\n> ");
      opcao = Console.ReadKey().KeyChar;
      Console.WriteLine();
      switch (opcao)
      {
        case '1':
          Tarefa novaTarefa = new Tarefa();
          novaTarefa.criarTarefa();
          tarefas.Add(novaTarefa);
          Console.WriteLine("Tarefa criada com sucesso!");
          break;
        case '2':
          listarTarefas();
          break;
        case '3':
          break;
        case '4':
          break;
        case '5':
          Console.Clear();
          Console.WriteLine("Encerrando...");
          break;
        default:
          Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
          break;
      }
      if (opcao != '5')
      {
        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
      }
    } while (opcao != '5');
  }
  public static void listarTarefas()
  {
    Console.Clear();
    Console.WriteLine("LISTA DE TAREFAS CRIADAS:\n");
    if (tarefas.Count == 0)
    {
      Console.WriteLine("Nenhuma tarefa criada...");
    }
    else
    {
      foreach (Tarefa tarefa in tarefas)
      {
        if (tarefa.StatusConclusao) Console.Write("CONCLUIDA - ");
        else Console.Write("PENDENTE - ");
        Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
        Console.WriteLine("Descrição: " + tarefa.Descricao);
      }
    }
  }

}