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
      // TODO criar estatistica sobre quantidade de tarefas
      // TODO criar estatistica sobre as tarefas mais antigas e recentes
      Console.WriteLine("GERENCIADOR DE TAREFAS");
      Console.WriteLine("1. Nova Tarefa");
      Console.WriteLine("2. Concluir Tarefa");
      Console.WriteLine("3. Pesquisar Tarefa");
      Console.WriteLine("4. Remover Tarefa");
      Console.WriteLine("5. Listar Tarefas");
      Console.Write("6. Exit\n> ");
      opcao = Console.ReadKey().KeyChar;
      Console.WriteLine();
      switch (opcao)
      {
        case '1':
          Tarefa novaTarefa = new Tarefa();
          novaTarefa.criarTarefa();
          if (novaTarefa.Titulo == "" || novaTarefa.Titulo == null || novaTarefa.Titulo == " ")
          {
            Console.WriteLine("Tarefa cancelada!");
          }
          else
          {
            tarefas.Add(novaTarefa);
            Console.WriteLine("\nTarefa criada com sucesso!");
          }
          break;
        case '2':
          conluirTarefa();
          break;
        case '3':
          // TODO Criar função que permite pesquisar tarefas
          break;
        case '4':
          removerTarefa();
          break;
        case '5':
          listarTarefas();
          break;
        case '6':
          Console.Clear();
          Console.WriteLine("Encerrando...");
          break;
        default:
          Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
          break;
      }
      if (opcao != '6')
      {
        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
      }
    } while (opcao != '6');
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
          Console.WriteLine("Nenhuma tarefa foi criada...");
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
            if (tarefa.StatusConclusao)
            {
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
            if (!tarefa.StatusConclusao)
            {
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
  public static void conluirTarefa()
  {
    // TODO resolver bug (Pedir outro id mesmo que já tenha concluido todas as tarefas)
    bool existeTarefasPendentes = false;
    int contador = 0;
    char? opcao = null;
    do
    {
      Console.Clear();
      Console.WriteLine("LISTA DE TAREFAS PENDENTES:\n");
      if (tarefas.Count == 0)
      {
        Console.WriteLine("Nenhuma tarefa foi criada...");
        return;
      }
      else
      {
        Console.WriteLine("[ID]");
        foreach (Tarefa tarefa in tarefas)
        {
          if (!tarefa.StatusConclusao)
          {
            Console.Write($"[{++contador}]  PENDENTE - ");
            Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
            existeTarefasPendentes = true;
          }
        }
        if (!existeTarefasPendentes)
        {
          Console.WriteLine("Todas as tarefas já foram concluidas...");
        }
        else
        {
          int idTarefa;
          do
          {
            Console.WriteLine("obs: Digite 0 para cancelar e voltar");
            Console.Write("Digite o ID da tarefa: ");
            Int32.TryParse(Console.ReadLine(), out idTarefa);
            if (idTarefa < 0 || idTarefa > tarefas.Count) Console.WriteLine("Essa tarefa não existe! Digite novamente...");
          } while (idTarefa < 0 || idTarefa > tarefas.Count);

          if (idTarefa == 0) opcao = 'N';
          else
          {
            tarefas[idTarefa - 1].StatusConclusao = true;
            Console.WriteLine("\nTarefa concluida com sucesso!\n");

            if (tarefas.Count > 1)
            {
              Console.Write("\nDeseja concluir mais tarefas? [S/N]\n> ");
              opcao = Console.ReadKey().KeyChar;
            }
          }
        }
      }
    } while (opcao != 'N' && opcao != 'n');
  }
  public static void removerTarefa()
  {
    int contador = 0;
    char? opcao = null;
    do
    {
      Console.Clear();
      Console.WriteLine("LISTA DE TAREFAS CRIADAS:\n");
      if (tarefas.Count == 0)
      {
        Console.WriteLine("Nenhuma tarefa foi criada...");
        return;
      }
      else
      {
        Console.WriteLine("[ID]");
        foreach (Tarefa tarefa in tarefas)
        {
          Console.Write($"[{++contador}]  PENDENTE - ");
          Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
          Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
        }
      }

      int idTarefa;
      do
      {
        Console.WriteLine("obs: Digite 0 para cancelar e voltar");
        Console.Write("Digite o ID da tarefa: ");
        Int32.TryParse(Console.ReadLine(), out idTarefa);
        if (idTarefa < 0 || idTarefa > tarefas.Count) Console.WriteLine("Essa tarefa não existe! Digite novamente...");
      } while (idTarefa < 0 || idTarefa > tarefas.Count);

      if (idTarefa == 0) opcao = 'N';
      else
      {
        tarefas.RemoveAt(idTarefa - 1);
        Console.WriteLine("\nTarefa removida com sucesso!\n");

        if (tarefas.Count > 1)
        {
          Console.Write("\nDeseja remover mais tarefas? [S/N]\n> ");
          opcao = Console.ReadKey().KeyChar;
        }
      }
    } while (opcao != 'N' && opcao != 'n');
  }
}