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
      Console.WriteLine("2. Listar Tarefas");
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
    char? opcao;

    Console.Clear();
    Console.WriteLine("GERENCIADOR DE TAREFAS");
    Console.WriteLine("1. Listar Todas as Tarefas Criadas");
    Console.WriteLine("2. Listar Tarefas Concluídas");
    Console.Write("3. Listar Tarefas Pendentes\n> ");
    opcao = Console.ReadKey().KeyChar;

    bool existeTarefas = false;

    switch (opcao)
    {
      case '1':
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
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
          }
        }
        break;
      case '2':
        Console.Clear();
        Console.WriteLine("LISTA DE TAREFAS CONCLUIDAS:\n");
        if (tarefas.Count == 0)
        {
          Console.WriteLine("Nenhuma tarefa criada...");
        }
        else
        {
          foreach (Tarefa tarefa in tarefas)
          {
            if (tarefa.StatusConclusao){
              Console.Write("CONCLUIDA - ");
              Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
              Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
              existeTarefas = true;
            }
          }
          if (!existeTarefas) Console.WriteLine("Ainda não concluiu nenhuma tarefa...");
        }
        break;
      case '3':
        Console.Clear();
        Console.WriteLine("LISTA DE TAREFAS PENDENTES:\n");
        if (tarefas.Count == 0)
        {
          Console.WriteLine("Nenhuma tarefa criada...");
        }
        else
        {
          foreach (Tarefa tarefa in tarefas)
          {
            if (!tarefa.StatusConclusao){
              Console.Write("PENDENTE - ");
              Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
              Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
              existeTarefas = true;
            }
          }
          if (!existeTarefas) Console.WriteLine("Todas as tarefas já foram concluidas...");
        }
        break;
      default:
        Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
        break;
    }
  }
}