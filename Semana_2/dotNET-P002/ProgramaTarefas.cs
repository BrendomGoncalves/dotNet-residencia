using System.Globalization;
class ProgramaTarefas
{
  private static List<Tarefa> tarefasConcluidas = new List<Tarefa>();
  private static List<Tarefa> tarefasPendentes = new List<Tarefa>();
  private static bool tarefasModificada = false;
  static void Main()
  {
    char opcao;
    do
    {
      Console.Clear();
      if (tarefasConcluidas.Count > 0 || tarefasPendentes.Count > 0) Console.WriteLine($"Mais recente: {tempoTarefa("r")}\nMais antiga: {tempoTarefa("a")}");
      Console.WriteLine($"[Pendentes: {tarefasPendentes.Count} | Concluidas: {tarefasConcluidas.Count} | Total: {tarefasPendentes.Count + tarefasConcluidas.Count}]");
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
            if (novaTarefa.StatusConclusao)
            {
              tarefasConcluidas.Add(novaTarefa);
              Console.WriteLine("\nTarefa criada e concluída com sucesso!");
            }
            else { }
            tarefasPendentes.Add(novaTarefa);
            Console.WriteLine("\nTarefa criada com sucesso!");
            tarefasModificada = true;
          }
          break;
        case '2':
          conluirTarefa();
          break;
        case '3':
          pesquisarTarefa();
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

    switch (opcao)
    {
      case '1':
        Console.Clear();
        Console.WriteLine("LISTA DE TAREFAS CRIADAS:\n");
        if (tarefasPendentes.Count == 0 && tarefasConcluidas.Count == 0)
        {
          Console.WriteLine("Nenhuma tarefa foi criada...");
        }
        else
        {
          foreach (Tarefa tarefa in tarefasPendentes)
          {
            Console.Write("PENDENTE - ");
            Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
          }
          foreach (Tarefa tarefa in tarefasConcluidas)
          {
            Console.Write("CONCLUIDA - ");
            Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
          }
        }
        break;
      case '2':
        Console.Clear();
        Console.WriteLine("LISTA DE TAREFAS CONCLUIDAS:\n");
        if (tarefasConcluidas.Count == 0)
        {
          Console.WriteLine("Não há tarefas...");
        }
        else
        {
          foreach (Tarefa tarefa in tarefasConcluidas)
          {
            Console.Write("CONCLUIDA - ");
            Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
          }
        }
        break;
      case '3':
        Console.Clear();
        Console.WriteLine("LISTA DE TAREFAS PENDENTES:\n");
        if (tarefasPendentes.Count == 0)
        {
          Console.WriteLine("Não há tarefas...");
        }
        else
        {
          foreach (Tarefa tarefa in tarefasPendentes)
          {
            Console.Write("PENDENTE - ");
            Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
            Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
          }
        }
        break;
      default:
        Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
        break;
    }
  }
  public static void conluirTarefa()
  {
    int contador;
    char? opcao;
    do
    {
      Console.Clear();
      Console.WriteLine("LISTA DE TAREFAS PENDENTES:\n");
      if (tarefasPendentes.Count == 0)
      {
        Console.WriteLine("Nenhuma tarefa pendente...");
        return;
      }
      else
      {
        Console.WriteLine("[ID]");
        contador = 0;
        foreach (Tarefa tarefa in tarefasPendentes)
        {
          contador++;
          if (!tarefa.StatusConclusao)
          {
            Console.Write($"[{contador}]  PENDENTE - ");
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
          if (idTarefa < 0 || idTarefa > tarefasPendentes.Count) Console.WriteLine("Essa tarefa não existe! Digite novamente...\n");
        } while (idTarefa < 0 || idTarefa > tarefasPendentes.Count);

        if (idTarefa == 0) opcao = 'N';
        else
        {
          tarefasPendentes[idTarefa - 1].StatusConclusao = true;
          tarefasConcluidas.Add(tarefasPendentes[idTarefa - 1]);
          //tarefasPendentes.RemoveAt(idTarefa - 1);
          tarefasPendentes.Remove(tarefasPendentes[idTarefa - 1]);
          Console.WriteLine("\nTarefa concluida com sucesso!");
          tarefasModificada = true;

          Console.Write("\nDeseja concluir mais tarefas? [S/N]\n> ");
          opcao = Console.ReadKey().KeyChar;
        }
      }
    } while (opcao != 'N' && opcao != 'n');
  }
  public static void removerTarefa()
  {
    if (tarefasConcluidas.Count > 0 || tarefasPendentes.Count > 0)
    {
      char? opcao = null;
      int opcaoTarefa, contador, idTarefa;
      do
      {
        Console.Clear();
        Console.WriteLine("GERENCIADOR DE TAREFAS");
        Console.WriteLine("Deseja remover uma tarefa:");
        Console.WriteLine("1. Concluida");
        Console.WriteLine("2. Pendente");
        Console.WriteLine("0. Cancelar\n> ");
        Console.Write("> ");
        opcaoTarefa = Console.ReadKey().KeyChar;

        contador = 0;
        Console.Clear();

        switch (opcaoTarefa)
        {
          case 1:
            Console.WriteLine("LISTA DE TAREFAS CONCLUIDAS:\n");
            Console.WriteLine("[ID]");
            foreach (Tarefa tarefa in tarefasConcluidas)
            {
              Console.Write($"[{++contador}]  CONCLUIDA - ");
              Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
              Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
            }
            do
            {
              Console.WriteLine("obs: Digite 0 para cancelar e voltar");
              Console.Write("Digite o ID da tarefa: ");
              Int32.TryParse(Console.ReadLine(), out idTarefa);
              if (idTarefa < 0 || idTarefa > tarefasConcluidas.Count) Console.WriteLine("Essa tarefa não existe! Digite novamente...");
            } while (idTarefa < 0 || idTarefa > tarefasConcluidas.Count);

            if (idTarefa == 0) opcao = 'N';
            else
            {
              tarefasConcluidas.RemoveAt(idTarefa - 1);
              Console.WriteLine("\nTarefa removida com sucesso!");
              tarefasModificada = true;
            }
            break;
          case 2:
            Console.WriteLine("LISTA DE TAREFAS PENDENTES:\n");
            Console.WriteLine("[ID]");
            foreach (Tarefa tarefa in tarefasPendentes)
            {
              Console.Write($"[{++contador}]  PENDENTE - ");
              Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
              Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
            }
            do
            {
              Console.WriteLine("obs: Digite 0 para cancelar e voltar");
              Console.Write("Digite o ID da tarefa: ");
              Int32.TryParse(Console.ReadLine(), out idTarefa);
              if (idTarefa < 0 || idTarefa > tarefasPendentes.Count) Console.WriteLine("Essa tarefa não existe! Digite novamente...");
            } while (idTarefa < 0 || idTarefa > tarefasPendentes.Count);

            if (idTarefa == 0) opcao = 'N';
            else
            {
              tarefasPendentes.RemoveAt(idTarefa - 1);
              Console.WriteLine("\nTarefa removida com sucesso!");
              tarefasModificada = true;
            }
            break;
          case 0:
            return;
          default:
            Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
            break;
        }
      } while (opcao != 'N' && opcao != 'n');
    }
    else
    {
      Console.WriteLine("Nenhuma tarefa foi criada...");
      return;
    }
  }
  public static void pesquisarTarefa()
  {
    bool existePendente = false, existeConcluida = false;
    string? pesquisa;

    do
    {
      Console.Clear();
      Console.WriteLine("GERENCIADOR DE TAREFAS");
      Console.Write("Digite o que deseja encontrar: ");
      pesquisa = Console.ReadLine();
      if (pesquisa == "" || pesquisa == null || pesquisa == " ") Console.WriteLine("\nPesquisa vazia, digite algo...");
    } while (pesquisa == "" || pesquisa == null || pesquisa == " ");

    Console.WriteLine("\nTarefas Pendentes:");
    foreach (Tarefa tarefa in tarefasPendentes)
    {
      if (tarefa.Titulo != null && tarefa.Descricao != null && (tarefa.Titulo.ToLower().Contains(pesquisa.ToLower()) || tarefa.Descricao.ToLower().Contains(pesquisa.ToLower())))
      {
        Console.Write("PENDENTE - ");
        Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
        Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
        existePendente = true;
      }
    }
    if (!existePendente) Console.WriteLine("Nenhuma tarefa pendente com esse termo...");

    Console.WriteLine("\nTarefas Concluídas:");
    foreach (Tarefa tarefa in tarefasConcluidas)
    {
      if (tarefa.Titulo != null && tarefa.Descricao != null && (tarefa.Titulo.ToLower().Contains(pesquisa.ToLower()) || tarefa.Descricao.ToLower().Contains(pesquisa.ToLower())))
      {
        Console.Write("CONCLUIDA - ");
        Console.WriteLine(tarefa.Titulo + " (" + tarefa.DataVencimento.ToString("dddd | dd/MM/yyyy | HH:mm", new CultureInfo("pt-BR")) + ")");
        Console.WriteLine("Descrição: " + tarefa.Descricao + "\n");
        existeConcluida = true;
      }
    }
    if (!existeConcluida) Console.WriteLine("Nenhuma tarefa concluída com esse termo...");
  }
  public static string tempoTarefa(string parametro)
  {
    Tarefa tempTarefa;

    if(!tarefasModificada){
      tarefasConcluidas.Sort(CompararTarefasPorDataVencimento);
      tarefasPendentes.Sort(CompararTarefasPorDataVencimento);
      tarefasModificada = false;
    }

    if (parametro == "r")
    {
      if(tarefasPendentes.Count > 0 && tarefasConcluidas.Count > 0)
        tempTarefa = (tarefasPendentes[0].DataVencimento > tarefasConcluidas[0].DataVencimento) ? tarefasPendentes[0] : tarefasConcluidas[0];
      else if(tarefasPendentes.Count > 0 && tarefasConcluidas.Count == 0) tempTarefa = tarefasPendentes[0];
      else tempTarefa = tarefasConcluidas[0];

      return $"{tempTarefa.Titulo} [{tempTarefa.DataVencimento.ToString("dd/MM")}]";
    }
    else if (parametro == "a")
    {
      int indexUltimoP = tarefasPendentes.Count - 1, indexUltimoC = tarefasConcluidas.Count - 1;
      if(tarefasPendentes.Count > 0 && tarefasConcluidas.Count > 0)
        tempTarefa = (tarefasPendentes[indexUltimoP].DataVencimento < tarefasConcluidas[indexUltimoC].DataVencimento) ? tarefasPendentes[indexUltimoP] : tarefasConcluidas[indexUltimoC];
      else if(tarefasPendentes.Count > 0 && tarefasConcluidas.Count == 0) tempTarefa = tarefasPendentes[indexUltimoP];
      else tempTarefa = tarefasConcluidas[indexUltimoC];

      return $"{tempTarefa.Titulo} [{tempTarefa.DataVencimento.ToString("dd/MM")}]";
    } else return "Sem tarefas";
  }
  private static int CompararTarefasPorDataVencimento(Tarefa t1, Tarefa t2)
  {
    return t1.DataVencimento.CompareTo(t2.DataVencimento);
  }
}